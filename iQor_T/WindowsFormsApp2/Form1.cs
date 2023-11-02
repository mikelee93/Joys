using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;

namespace WindowsFormsApp2
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
            this.Text = "iQor outbound ver 1.4";

            DataGridViewTextBoxColumn lastUpdatedColumn = new DataGridViewTextBoxColumn();
            lastUpdatedColumn.Name = "lastUpdated";
            lastUpdatedColumn.HeaderText = "Last Updated";
            dgviQor.Columns.Add(lastUpdatedColumn);

            string[] newColumns = { "orderprocessing", "shipping", "packing", "smartdeploy", "imaging" };
            foreach (string colName in newColumns)
            {
                DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
                newColumn.Name = colName;
                newColumn.HeaderText = colName;
                dgviQor.Columns.Add(newColumn);
            }
        }

        public void Loadrecords()
        {
            dgviQor.Rows.Clear();
            int i = 0;
            con.Open();
            cmd = new SqlCommand("SELECT * FROM IQor_T", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgviQor.Rows.Add(i, dr["companyname"].ToString(),
                    dr["fname"].ToString(),
                    dr["lname"].ToString(),
                    dr["street"].ToString(),
                    dr["street2"].ToString(),
                    dr["city"].ToString(),
                    dr["state"].ToString(),
                    dr["zip"].ToString(),
                    dr["country"].ToString(),
                    dr["phone"].ToString(),
                    dr["email"].ToString(),
                    dr["domainID"].ToString(),
                    dr["costcenter"].ToString(),
                    dr["shipmethod"].ToString(),
                    dr["returnLabel"].ToString(),
                    dr["ordernumber"].ToString(),
                    dr["lotnumber"].ToString(),
                    dr["typename"].ToString(),
                    dr["brandname"].ToString(),
                    dr["modelname"].ToString(),
                    dr["pnum"].ToString(),
                    dr["formfactor"].ToString(),
                    dr["color"].ToString(),
                    dr["cpu"].ToString(),
                    dr["ramtype"].ToString(),
                    dr["ramsize"].ToString(),
                    dr["subtypehddname"].ToString(),
                    dr["shellsize"].ToString(),
                    dr["hdd"].ToString(),
                    dr["cd"].ToString(),
                    dr["wifi"].ToString(),
                    dr["screensize"].ToString(),
                    dr["webcam"].ToString(),
                    dr["touch"].ToString(),
                    dr["productsidx"].ToString(),
                    dr["jnum"].ToString(),
                    dr["snum"].ToString(),
                    dr["qty"].ToString(),
                    dr["trackingnumber"].ToString(),
                    dr["shippedDate"].ToString(),
                    dr["returnQty"].ToString(),
                    dr["returnTracking"].ToString(),
                    dr["returnedDate"].ToString(),
                    dr["condition"].ToString(),
                    dr["repairable"].ToString(),
                    dr["macAddress"].ToString(),
                    dr["productKey"].ToString(),
                    dr["image"].ToString(),
                    dr["pcName"].ToString(),
                    dr["lastEntered"].ToString(),
                    dr["orderprocessing"].ToString(),
                    dr["shipping"].ToString(),
                    dr["packing"].ToString(),
                    dr["smartdeploy"].ToString(),
                    dr["imaging"].ToString(),
                    dr["lastUpdated"].ToString());
            }
            dr.Close();
            con.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                for (int i = 0; i < dgviQor.Rows.Count; i++)
                {
                    string typenameValue = dgviQor.Rows[i].Cells[18].Value.ToString();
                    string snumValue = dgviQor.Rows[i].Cells[37].Value != DBNull.Value ? dgviQor.Rows[i].Cells[37].Value.ToString() : "0";
                    string pcNameValue;

                    if (typenameValue == "Desktop" || typenameValue == "Thin Client")
                    {
                        pcNameValue = "iQor_" + snumValue;
                    }
                    else
                    {
                        pcNameValue = dgviQor.Rows[i].Cells[49].Value.ToString();
                    }
                    cmd = new SqlCommand("INSERT INTO iQor_T (companyname,fname,lname,street,street2,city,state,zip,country,phone,email,domainID,costcenter,shipmethod,returnLabel,ordernumber,lotnumber,typename,brandname,modelname,pnum,formfactor,color,cpu,ramtype,ramsize,subtypehddname,shellsize,hdd,cd,wifi,screensize,webcam,touch,productsidx,jnum,snum,qty,trackingnumber,shippedDate,returnQty,returnTracking,returnedDate,condition,repairable,macAddress,productKey,image,pcName,lastEntered,orderprocessing,shipping,packing,smartdeploy,imaging,lastUpdated ) " +
                        "VALUES (@companyname,@fname,@lname,@street,@street2,@city,@state,@zip,@country,@phone,@email,@domainID,@costcenter,@shipmethod,@returnLabel,@ordernumber,@lotnumber,@typename,@brandname,@modelname,@pnum,@formfactor,@color,@cpu,@ramtype,@ramsize,@subtypehddname,@shellsize,@hdd,@cd,@wifi,@screensize,@webcam,@touch,@productsidx,@jnum,@snum,@qty,@trackingnumber,@shippedDate,@returnQty,@returnTracking,@returnedDate,@condition,@repairable,@macAddress,@productKey,@image,@pcName,@lastEntered,@orderprocessing,@shipping,@packing,@smartdeploy,@imaging,@lastUpdated)", con);
                    cmd.Parameters.AddWithValue("@companyname", dgviQor.Rows[i].Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@fname", dgviQor.Rows[i].Cells[2].Value.ToString());
                    cmd.Parameters.AddWithValue("@lname", dgviQor.Rows[i].Cells[3].Value.ToString());
                    cmd.Parameters.AddWithValue("@street", dgviQor.Rows[i].Cells[4].Value.ToString());
                    cmd.Parameters.AddWithValue("@street2", dgviQor.Rows[i].Cells[5].Value.ToString());
                    cmd.Parameters.AddWithValue("@city", dgviQor.Rows[i].Cells[6].Value.ToString());
                    cmd.Parameters.AddWithValue("@state", dgviQor.Rows[i].Cells[7].Value.ToString());
                    cmd.Parameters.AddWithValue("@zip", dgviQor.Rows[i].Cells[8].Value.ToString());
                    cmd.Parameters.AddWithValue("@country", dgviQor.Rows[i].Cells[9].Value.ToString());
                    cmd.Parameters.AddWithValue("@phone", dgviQor.Rows[i].Cells[10].Value.ToString());
                    cmd.Parameters.AddWithValue("@email", dgviQor.Rows[i].Cells[11].Value.ToString());
                    cmd.Parameters.AddWithValue("@domainID", dgviQor.Rows[i].Cells[12].Value.ToString());
                    cmd.Parameters.AddWithValue("@costcenter", dgviQor.Rows[i].Cells[13].Value.ToString());
                    cmd.Parameters.AddWithValue("@shipmethod", dgviQor.Rows[i].Cells[14].Value.ToString());
                    cmd.Parameters.AddWithValue("@returnLabel", dgviQor.Rows[i].Cells[15].Value.ToString());
                    cmd.Parameters.AddWithValue("@ordernumber", dgviQor.Rows[i].Cells[16].Value.ToString());
                    cmd.Parameters.AddWithValue("@lotnumber", dgviQor.Rows[i].Cells[17].Value.ToString());
                    cmd.Parameters.AddWithValue("@typename", dgviQor.Rows[i].Cells[18].Value.ToString());
                    cmd.Parameters.AddWithValue("@brandname", dgviQor.Rows[i].Cells[19].Value.ToString());
                    cmd.Parameters.AddWithValue("@modelname", dgviQor.Rows[i].Cells[20].Value.ToString());
                    cmd.Parameters.AddWithValue("@pnum", dgviQor.Rows[i].Cells[21].Value.ToString());
                    cmd.Parameters.AddWithValue("@formfactor", dgviQor.Rows[i].Cells[22].Value.ToString());
                    cmd.Parameters.AddWithValue("@color", dgviQor.Rows[i].Cells[23].Value.ToString());
                    cmd.Parameters.AddWithValue("@cpu", dgviQor.Rows[i].Cells[24].Value.ToString());
                    cmd.Parameters.AddWithValue("@ramtype", dgviQor.Rows[i].Cells[25].Value.ToString());
                    cmd.Parameters.AddWithValue("@ramsize", dgviQor.Rows[i].Cells[26].Value.ToString());
                    cmd.Parameters.AddWithValue("@subtypehddname", dgviQor.Rows[i].Cells[27].Value.ToString());
                    cmd.Parameters.AddWithValue("@shellsize", dgviQor.Rows[i].Cells[28].Value.ToString());
                    cmd.Parameters.AddWithValue("@hdd", dgviQor.Rows[i].Cells[29].Value.ToString());
                    cmd.Parameters.AddWithValue("@cd", dgviQor.Rows[i].Cells[30].Value.ToString());
                    cmd.Parameters.AddWithValue("@wifi", dgviQor.Rows[i].Cells[31].Value.ToString());
                    cmd.Parameters.AddWithValue("@screensize", dgviQor.Rows[i].Cells[32].Value.ToString());
                    cmd.Parameters.AddWithValue("@webcam", dgviQor.Rows[i].Cells[33].Value.ToString());
                    cmd.Parameters.AddWithValue("@touch", dgviQor.Rows[i].Cells[34].Value.ToString());
                    cmd.Parameters.AddWithValue("@productsidx", dgviQor.Rows[i].Cells[35].Value.ToString());
                    cmd.Parameters.AddWithValue("@jnum", dgviQor.Rows[i].Cells[36].Value.ToString());
                    cmd.Parameters.AddWithValue("@snum", dgviQor.Rows[i].Cells[37].Value.ToString());
                    cmd.Parameters.AddWithValue("@qty", dgviQor.Rows[i].Cells[38].Value.ToString());
                    cmd.Parameters.AddWithValue("@trackingnumber", dgviQor.Rows[i].Cells[39].Value.ToString());
                    cmd.Parameters.AddWithValue("@shippedDate", dgviQor.Rows[i].Cells[40].Value.ToString());
                    cmd.Parameters.AddWithValue("@returnQty", dgviQor.Rows[i].Cells[41].Value.ToString());
                    cmd.Parameters.AddWithValue("@returnTracking", dgviQor.Rows[i].Cells[42].Value.ToString());
                    cmd.Parameters.AddWithValue("@condition", dgviQor.Rows[i].Cells[44].Value.ToString());
                    cmd.Parameters.AddWithValue("@repairable", dgviQor.Rows[i].Cells[45].Value.ToString());
                    cmd.Parameters.AddWithValue("@macAddress", dgviQor.Rows[i].Cells[46].Value.ToString());
                    cmd.Parameters.AddWithValue("@productKey", dgviQor.Rows[i].Cells[47].Value.ToString());
                    cmd.Parameters.AddWithValue("@image", dgviQor.Rows[i].Cells[48].Value.ToString());
                    cmd.Parameters.AddWithValue("@pcName", pcNameValue);
                    cmd.Parameters.AddWithValue("@lastEntered", dgviQor.Rows[i].Cells[50].Value.ToString());
                    cmd.Parameters.AddWithValue("@orderprocessing", dgviQor.Rows[i].Cells[51].Value.ToString());
                    cmd.Parameters.AddWithValue("@shipping", dgviQor.Rows[i].Cells[52].Value.ToString());
                    cmd.Parameters.AddWithValue("@packing", dgviQor.Rows[i].Cells[53].Value.ToString());
                    cmd.Parameters.AddWithValue("@smartdeploy", dgviQor.Rows[i].Cells[54].Value.ToString());
                    cmd.Parameters.AddWithValue("@imaging", dgviQor.Rows[i].Cells[55].Value.ToString());
                    DateTime returnedDateValue;
                    DateTime lastEntered;

                    bool isLastEnteredValid = DateTime.TryParse(dgviQor.Rows[i].Cells[56].Value.ToString(), out lastEntered);
                    cmd.Parameters.AddWithValue("@lastUpdated", DateTime.Now);

                    if (DateTime.TryParse(dgviQor.Rows[i].Cells[43].Value.ToString(), out returnedDateValue))
                    {
                        if (returnedDateValue == DateTime.Parse("1900-01-01 00:00:00.000"))
                        {
                            returnedDateValue = new DateTime(1753, 1, 1);
                        }
                        cmd.Parameters.AddWithValue("@returnedDate", returnedDateValue);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@returnedDate", DBNull.Value);
                    }

                    cmd.ExecuteNonQuery();
                    string jnumValue = dgviQor.Rows[i].Cells[36].Value != DBNull.Value ? dgviQor.Rows[i].Cells[36].Value.ToString() : "0";


                    if (typenameValue == "Desktop")
                    {
                        string productKeyQuery = @"
                        SELECT d.productKey
                        FROM digitalcoa_T d 
                        WHERE d.snum = @snum";

                        SqlCommand productKeyCmd = new SqlCommand(productKeyQuery, con);
                        productKeyCmd.Parameters.AddWithValue("@snum", snumValue);

                        using (SqlDataReader reader = productKeyCmd.ExecuteReader())
                        {
                            List<string> allProductKeys = new List<string>();
                            while (reader.Read())
                            {
                                allProductKeys.Add(reader.GetString(0));
                            }
                            reader.Close();

                            foreach (string foundProductKey in allProductKeys)
                            {
                                string updateQuery = @"
                                UPDATE iQor_T 
                                SET productkey = @productKey 
                                WHERE snum = @snum AND typename = 'Desktop'";

                                SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                                updateCmd.Parameters.AddWithValue("@snum", snumValue);
                                updateCmd.Parameters.AddWithValue("@productKey", foundProductKey);

                                updateCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(jnumValue) && jnumValue != "0")
                    {
                        string idxQuery = @"
                        SELECT p.idx
                        FROM products p
                        WHERE p.jnum = @jnum";

                        SqlCommand idxCmd = new SqlCommand(idxQuery, con);
                        idxCmd.Parameters.AddWithValue("@jnum", jnumValue);

                        object resultIdx = idxCmd.ExecuteScalar();
                        if (resultIdx != null)
                        {
                            int foundIdx = Convert.ToInt32(resultIdx);

                            string updateIdxQuery = @"
                            UPDATE iQor_T 
                            SET productsidx = @idx
                            WHERE jnum = @jnum";

                            SqlCommand updateIdxCmd = new SqlCommand(updateIdxQuery, con);
                            updateIdxCmd.Parameters.AddWithValue("@jnum", jnumValue);
                            updateIdxCmd.Parameters.AddWithValue("@idx", foundIdx);

                            updateIdxCmd.ExecuteNonQuery();
                        }
                    }
                    else if (string.IsNullOrEmpty(jnumValue))
                    {
                        string updateIdxQuery = @"
                        UPDATE iQor_T 
                        SET productsidx = 0
                        WHERE jnum = @jnum OR jnum = ''";

                        SqlCommand updateIdxCmd = new SqlCommand(updateIdxQuery, con);
                        updateIdxCmd.Parameters.AddWithValue("@jnum", jnumValue);

                        updateIdxCmd.ExecuteNonQuery();
                    }

                    if (typenameValue == "Desktop" || typenameValue == "Thin Client")
                    {
                        if (string.IsNullOrEmpty(pcNameValue))
                        {
                            string formattedPCName = "iQor_" + snumValue;
                            string updatePCNameQuery = @"
                            UPDATE iQor_T 
                            SET pcName = @snum 
                            WHERE jnum = @jnum";

                            SqlCommand updatePCNameCmd = new SqlCommand(updatePCNameQuery, con);
                            updatePCNameCmd.Parameters.AddWithValue("@jnum", jnumValue);
                            updatePCNameCmd.Parameters.AddWithValue("@snum", snumValue);

                            updatePCNameCmd.ExecuteNonQuery();
                        }

                        if (typenameValue == "Thin Client")
                        {
                            string macAddressQuery = @"
                            SELECT p.macAddress
                            FROM products p 
                            WHERE p.jnum = @jnum";

                            SqlCommand macCmd = new SqlCommand(macAddressQuery, con);
                            macCmd.Parameters.AddWithValue("@jnum", jnumValue);

                            object macResult = macCmd.ExecuteScalar();
                            if (macResult != null)
                            {
                                string foundMacAddress = macResult.ToString();

                                string updateMacQuery = @"
                                UPDATE iQor_T 
                                SET macAddress = @macAddress 
                                WHERE jnum = @jnum";

                                SqlCommand updateMacCmd = new SqlCommand(updateMacQuery, con);
                                updateMacCmd.Parameters.AddWithValue("@jnum", jnumValue);
                                updateMacCmd.Parameters.AddWithValue("@macAddress", foundMacAddress);

                                updateMacCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            MessageBox.Show("RECORDS SUCCESSFULLY SAVED.", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            dgviQor.Rows.Clear();

            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorksheet;
            Microsoft.Office.Interop.Excel.Range xlRange;

            int xlRow;
            string strFileName;

            openFD.Filter = "Excel Office |*.xls;*.xlsx";
            openFD.ShowDialog();
            strFileName = openFD.FileName;

            if (strFileName != "")
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(strFileName);
                xlWorksheet = xlWorkbook.Worksheets[1];
                xlRange = xlWorksheet.UsedRange;

                int i = 0;

                for (xlRow = 2; xlRow <= xlRange.Rows.Count; xlRow++)
                {
                    if (xlRange.Cells[xlRow, 1].Text != "")
                    {

                    }

                    dgviQor.Rows.Add(i, xlRange.Cells[xlRow, 1].Text,
                        xlRange.Cells[xlRow, 2].Text,
                        xlRange.Cells[xlRow, 3].Text,
                        xlRange.Cells[xlRow, 4].Text,
                        xlRange.Cells[xlRow, 5].Text,
                        xlRange.Cells[xlRow, 6].Text,
                        xlRange.Cells[xlRow, 7].Text,
                        xlRange.Cells[xlRow, 8].Text,
                        xlRange.Cells[xlRow, 9].Text,
                        xlRange.Cells[xlRow, 10].Text,
                        xlRange.Cells[xlRow, 11].Text,
                        xlRange.Cells[xlRow, 12].Text,
                        xlRange.Cells[xlRow, 13].Text,
                        xlRange.Cells[xlRow, 14].Text,
                        xlRange.Cells[xlRow, 15].Text,
                        xlRange.Cells[xlRow, 16].Text,
                        xlRange.Cells[xlRow, 17].Text,
                        xlRange.Cells[xlRow, 18].Text,
                        xlRange.Cells[xlRow, 19].Text,
                        xlRange.Cells[xlRow, 20].Text,
                        xlRange.Cells[xlRow, 21].Text,
                        xlRange.Cells[xlRow, 22].Text,
                        xlRange.Cells[xlRow, 23].Text,
                        xlRange.Cells[xlRow, 24].Text,
                        xlRange.Cells[xlRow, 25].Text,
                        xlRange.Cells[xlRow, 26].Text,
                        xlRange.Cells[xlRow, 27].Text,
                        xlRange.Cells[xlRow, 28].Text,
                        xlRange.Cells[xlRow, 29].Text,
                        xlRange.Cells[xlRow, 30].Text,
                        xlRange.Cells[xlRow, 31].Text,
                        xlRange.Cells[xlRow, 32].Text,
                        xlRange.Cells[xlRow, 33].Text,
                        xlRange.Cells[xlRow, 34].Text,
                        xlRange.Cells[xlRow, 35].Text,
                        xlRange.Cells[xlRow, 36].Text,
                        xlRange.Cells[xlRow, 37].Text,
                        xlRange.Cells[xlRow, 38].Text,
                        xlRange.Cells[xlRow, 39].Text,
                        xlRange.Cells[xlRow, 40].Text,
                        xlRange.Cells[xlRow, 41].Text,
                        xlRange.Cells[xlRow, 42].Text,
                        xlRange.Cells[xlRow, 43].Text,
                        xlRange.Cells[xlRow, 44].Text,
                        xlRange.Cells[xlRow, 45].Text,
                        xlRange.Cells[xlRow, 46].Text,
                        xlRange.Cells[xlRow, 47].Text,
                        xlRange.Cells[xlRow, 48].Text,
                        xlRange.Cells[xlRow, 49].Text,
                        xlRange.Cells[xlRow, 50].Text,
                        xlRange.Cells[xlRow, 51].Text,
                        xlRange.Cells[xlRow, 52].Text,
                        xlRange.Cells[xlRow, 53].Text,
                        xlRange.Cells[xlRow, 54].Text,
                        xlRange.Cells[xlRow, 55].Text,
                        xlRange.Cells[xlRow, 56].Text,
                        DateTime.Now.ToString());
                        
                }
                xlWorkbook.Close();
                xlApp.Quit();

                btnSave_Click(sender, e);

                dgviQor.Rows.Clear();
            }
        }

        private void dgviQor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
