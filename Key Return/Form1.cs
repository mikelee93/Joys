using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using OfficeOpenXml;


namespace Key_Return
{

    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        ConnectionDB db = new ConnectionDB();
        public Form1()
        {
            InitializeComponent();

            con = new SqlConnection(db.ConnectionString);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files|*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    string[] headers = sr.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        dt.Columns.Add(header);
                    }
                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i];
                        }
                        dt.Rows.Add(dr);
                    }
                }

                dgvKeyReturn.AutoGenerateColumns = true;
                dgvKeyReturn.DataSource = dt;
                dgvKeyReturn.AutoGenerateColumns = false;

                for (int i = dgvKeyReturn.Columns.Count - 1; i >= 0; i--)
                {
                    if (dgvKeyReturn.Columns[i].DataPropertyName != "ProductKeyId" && dgvKeyReturn.Columns[i].DataPropertyName != "ReturnCode")
                    {
                        dgvKeyReturn.Columns.RemoveAt(i);
                    }
                }

                foreach (DataColumn column in dt.Columns)
                {
                    Console.WriteLine(column.ColumnName);
                }
            }
            btnSave_Click(sender, e);
            dgvKeyReturn.DataSource = null;
            dgvKeyReturn.Rows.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> productKeyIds = new List<string>();
            foreach (DataGridViewRow row in dgvKeyReturn.Rows)
            {
                if (row.Cells["ProductKeyId"].Value != null)
                {
                    productKeyIds.Add(row.Cells["ProductKeyId"].Value.ToString());
                }
            }

            string inClause = string.Join(",", productKeyIds);

            List<string> returnedProductKeyIds = ExecuteSelectProductKey(inClause);
            ExecuteInsertKeyHistory(inClause);
            ExecuteUpdateProductKey(inClause);
            List<int> keyHistoryIds = ExecuteSelectKeyHistoryForUpdate();
            UpdateLastKeyHistoryId(returnedProductKeyIds);

            MessageBox.Show("Saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExecuteUpdateProductKey(string inClause)
        {
            string query = "update ProductKey set ProductKeyStateID=5, productkeystate = 'Returned' where MSFTProductKeyId In (" + inClause + ")";
            using (SqlConnection conn = new SqlConnection(db.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private List<string> ExecuteSelectProductKey(string inClause)
        {
            string query = @"select productkey.productkeyid, productkey.ffkiproductkeyid 
               from productkey 
               join keyhistory on (keyhistory.keyhistoryid = productkey.lastkeyhistoryid) 
               where productkey.productkeystate = 'ActivationEnabled' and productkey.msftproductkeyid in (" + inClause + ")";
            con.Open();
            List<string> returnedProductKeyIds = new List<string>();
            using (cmd = new SqlCommand(query, con))
            {
                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        long productKeyIdFromDB = dr.GetInt64(0);
                        returnedProductKeyIds.Add(productKeyIdFromDB.ToString());
                        //MessageBox.Show($"ProductKeyId from database: {productKeyIdFromDB}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            con.Close();
            //MessageBox.Show("ExecuteSelectProductKey completed.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return returnedProductKeyIds;
        }

        private void ExecuteInsertKeyHistory(string inClause)
        {
            string sqlConnectionString = db.ConnectionString;

            string queryInsert = @"INSERT INTO keyhistory (productkeyid, ffkiproductkeyid, productkeystateid, modifieddatetime, userid, profileid, ismigrated)
                           SELECT productkeyid, ffkiproductkeyid, 5, GETDATE(), 0, 1, 0
                           FROM [ProductKey]
                           WHERE MSFTProductKeyId IN (" + inClause + ")";

            using (SqlConnection conn = new SqlConnection(sqlConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

       private List<int> ExecuteSelectKeyHistoryForUpdate()
        {
            string querySelectKeyHistory = @"SELECT keyhistory.keyhistoryid, keyhistory.productkeyid 
                                          FROM keyhistory 
                                          JOIN keystate ON (keystate.keystateid = keyhistory.productkeystateid)
                                          JOIN productkey ON (productkey.ProductKeyID = keyhistory.ProductKeyID)
                                          WHERE keyhistory.productkeyid IN (
                                              SELECT productkey.productkeyid 
                                              FROM productkey 
                                              JOIN keyhistory ON (keyhistory.keyhistoryid = productkey.lastkeyhistoryid)
                                              WHERE productkeystate IN ('Returned') 
                                              AND productkey.ProductKeyStateID <> keyhistory.ProductKeyStateID
                                          ) 
                                          AND keyhistory.ProductKeyStateID = 5";
            List<int> keyHistoryIds = new List<int>();

            using (SqlConnection conn = new SqlConnection(db.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(querySelectKeyHistory, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            keyHistoryIds.Add(reader.GetInt32(0));
                        }
                    }
                }
            }
            return keyHistoryIds;
        }

        private void UpdateLastKeyHistoryId(List<string> productKeyIds)
        {
            using (SqlConnection conn = new SqlConnection(db.ConnectionString))
            {
                conn.Open();

                string updateProductKeyQuery = @"
                UPDATE productkey 
                SET LastKeyHistoryId = (
                    SELECT TOP 1 kh.keyhistoryid 
                    FROM keyhistory kh 
                    WHERE kh.productkeyid = @ProductKeyId 
                    ORDER BY kh.keyhistoryid DESC
                )
                WHERE productkeyid = @ProductKeyId";

                using (SqlCommand cmd = new SqlCommand(updateProductKeyQuery, conn))
                {
                    foreach (string productKeyId in productKeyIds)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ProductKeyId", productKeyId);
                        cmd.ExecuteNonQuery();
                        //MessageBox.Show($"UpdateLastKeyHistoryId completed for ProductKeyId: {productKeyId}.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dgvKeyReturn_CellContentClick(object sender, DataGridViewCellEventArgs e)
                {

                }
            }
        }

