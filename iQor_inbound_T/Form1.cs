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

namespace iQor_inbound_T
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
            DataGridViewTextBoxColumn lastUpdatedColumn = new DataGridViewTextBoxColumn();
            lastUpdatedColumn.Name = "lastUpdated";
            lastUpdatedColumn.HeaderText = "Last Updated";
            dgviQor_inbound.Columns.Add(lastUpdatedColumn);

            con = new SqlConnection(db.ConnectionString);
        }
        public void Loadrecords()
        {
            dgviQor_inbound.Rows.Clear();
            int i = 0;
            con.Open();
            cmd = new SqlCommand("SELECT * FROM IQor_inbound_T", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;

                dgviQor_inbound.Rows.Add(i, dr["vendorname"].ToString(),
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
                    dr["condition"].ToString(),
                    dr["repairable"].ToString(),
                    dr["trackingnumber"].ToString(),
                    dr["receivedDate"].ToString(),
                    dr["shippedDate"].ToString(),
                    dr["qty"].ToString(),
                    dr["macAddress"].ToString(),
                    dr["lastEntered"].ToString(),
                    dr["receiving"].ToString(),
                    dr["inspection"].ToString(),
                    dr["onoffTest"].ToString(),
                    dr["fullpcAudit"].ToString(),
                    dr["lastUpdated"].ToString());
            }
            dr.Close();
            con.Close();
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            dgviQor_inbound.Rows.Clear();

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
                    string lastEntered = xlRange.Cells[xlRow, 42].Text;

                    dgviQor_inbound.Rows.Add(i, xlRange.Cells[xlRow, 1].Text,
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
                        DateTime.Now.ToString());

                    i++;
                }

                xlWorkbook.Close();
                xlApp.Quit();

                btnSave_Click(sender, e);
                dgviQor_inbound.Rows.Clear();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (con)
                {
                    con.Open();
                    for (int i = 0; i < dgviQor_inbound.Rows.Count; i++)
                    {
                        using (cmd = new SqlCommand("INSERT INTO iQor_inbound_T (vendorname,fname,lname,street,street2,city,state,zip,country,phone,email,ordernumber,lotnumber,typename,brandname,modelname,pnum,formfactor,color,cpu,ramtype,ramsize,subtypehddname,shellsize,hdd,cd,wifi,screensize,webcam,touch,productsidx,jnum,snum,condition,repairable,trackingnumber,receivedDate,shippedDate,qty,macAddress,lastEntered,receiving,inspection,onoffTest,fullpcAudit,lastUpdated) " +
                           "VALUES (@vendorname,@fname,@lname,@street,@street2,@city,@state,@zip,@country,@phone,@email,@ordernumber,@lotnumber,@typename,@brandname,@modelname,@pnum,@formfactor,@color,@cpu,@ramtype,@ramsize,@subtypehddname,@shellsize,@hdd,@cd,@wifi,@screensize,@webcam,@touch,@productsidx,@jnum,@snum,@condition,@repairable,@trackingnumber,@receivedDate,@shippedDate,@qty,@macAddress,@lastEntered,@receiving,@inspection,@onoffTest,@fullpcAudit,@lastUpdated)", con))
                        {
                            cmd.Parameters.AddWithValue("@vendorname", dgviQor_inbound.Rows[i].Cells[1].Value.ToString());
                            cmd.Parameters.AddWithValue("@fname", dgviQor_inbound.Rows[i].Cells[2].Value.ToString());
                            cmd.Parameters.AddWithValue("@lname", dgviQor_inbound.Rows[i].Cells[3].Value.ToString());
                            cmd.Parameters.AddWithValue("@street", dgviQor_inbound.Rows[i].Cells[4].Value.ToString());
                            cmd.Parameters.AddWithValue("@street2", dgviQor_inbound.Rows[i].Cells[5].Value.ToString());
                            cmd.Parameters.AddWithValue("@city", dgviQor_inbound.Rows[i].Cells[6].Value.ToString());
                            cmd.Parameters.AddWithValue("@state", dgviQor_inbound.Rows[i].Cells[7].Value.ToString());
                            cmd.Parameters.AddWithValue("@zip", dgviQor_inbound.Rows[i].Cells[8].Value.ToString());
                            cmd.Parameters.AddWithValue("@country", dgviQor_inbound.Rows[i].Cells[9].Value.ToString());
                            cmd.Parameters.AddWithValue("@phone", dgviQor_inbound.Rows[i].Cells[10].Value.ToString());
                            cmd.Parameters.AddWithValue("@email", dgviQor_inbound.Rows[i].Cells[11].Value.ToString());
                            cmd.Parameters.AddWithValue("@ordernumber", dgviQor_inbound.Rows[i].Cells[12].Value.ToString());
                            cmd.Parameters.AddWithValue("@lotnumber", dgviQor_inbound.Rows[i].Cells[13].Value.ToString());
                            cmd.Parameters.AddWithValue("@typename", dgviQor_inbound.Rows[i].Cells[14].Value.ToString());
                            cmd.Parameters.AddWithValue("@brandname", dgviQor_inbound.Rows[i].Cells[15].Value.ToString());
                            cmd.Parameters.AddWithValue("@modelname", dgviQor_inbound.Rows[i].Cells[16].Value.ToString());
                            cmd.Parameters.AddWithValue("@pnum", dgviQor_inbound.Rows[i].Cells[17].Value.ToString());
                            cmd.Parameters.AddWithValue("@formfactor", dgviQor_inbound.Rows[i].Cells[18].Value.ToString());
                            cmd.Parameters.AddWithValue("@color", dgviQor_inbound.Rows[i].Cells[19].Value.ToString());
                            cmd.Parameters.AddWithValue("@cpu", dgviQor_inbound.Rows[i].Cells[20].Value.ToString());
                            cmd.Parameters.AddWithValue("@ramtype", dgviQor_inbound.Rows[i].Cells[21].Value.ToString());
                            cmd.Parameters.AddWithValue("@ramsize", dgviQor_inbound.Rows[i].Cells[22].Value.ToString());
                            cmd.Parameters.AddWithValue("@subtypehddname", dgviQor_inbound.Rows[i].Cells[23].Value.ToString());
                            cmd.Parameters.AddWithValue("@shellsize", dgviQor_inbound.Rows[i].Cells[24].Value.ToString());
                            cmd.Parameters.AddWithValue("@hdd", dgviQor_inbound.Rows[i].Cells[25].Value.ToString());
                            cmd.Parameters.AddWithValue("@cd", dgviQor_inbound.Rows[i].Cells[26].Value.ToString());
                            cmd.Parameters.AddWithValue("@wifi", dgviQor_inbound.Rows[i].Cells[27].Value.ToString());
                            cmd.Parameters.AddWithValue("@screensize", dgviQor_inbound.Rows[i].Cells[28].Value.ToString());
                            cmd.Parameters.AddWithValue("@webcam", dgviQor_inbound.Rows[i].Cells[29].Value.ToString());
                            cmd.Parameters.AddWithValue("@touch", dgviQor_inbound.Rows[i].Cells[30].Value.ToString());
                            cmd.Parameters.AddWithValue("@productsidx", dgviQor_inbound.Rows[i].Cells[31].Value.ToString());
                            cmd.Parameters.AddWithValue("@jnum", dgviQor_inbound.Rows[i].Cells[32].Value.ToString());
                            cmd.Parameters.AddWithValue("@snum", dgviQor_inbound.Rows[i].Cells[33].Value.ToString());
                            cmd.Parameters.AddWithValue("@condition", dgviQor_inbound.Rows[i].Cells[34].Value.ToString());
                            cmd.Parameters.AddWithValue("@repairable", dgviQor_inbound.Rows[i].Cells[35].Value.ToString());
                            cmd.Parameters.AddWithValue("@trackingnumber", dgviQor_inbound.Rows[i].Cells[36].Value.ToString());
                            cmd.Parameters.AddWithValue("@receivedDate", dgviQor_inbound.Rows[i].Cells[37].Value.ToString());
                            cmd.Parameters.AddWithValue("@qty", dgviQor_inbound.Rows[i].Cells[39].Value.ToString());
                            cmd.Parameters.AddWithValue("@macAddress", dgviQor_inbound.Rows[i].Cells[40].Value.ToString());
                            cmd.Parameters.AddWithValue("@lastEntered", dgviQor_inbound.Rows[i].Cells[41].Value.ToString());
                            cmd.Parameters.AddWithValue("@receiving", dgviQor_inbound.Rows[i].Cells[42].Value.ToString());
                            cmd.Parameters.AddWithValue("@inspection", dgviQor_inbound.Rows[i].Cells[43].Value.ToString());
                            cmd.Parameters.AddWithValue("@onoffTest", dgviQor_inbound.Rows[i].Cells[44].Value.ToString());
                            cmd.Parameters.AddWithValue("@fullpcAudit", dgviQor_inbound.Rows[i].Cells[45].Value.ToString());
                            cmd.Parameters.AddWithValue("@lastUpdated", DateTime.Now);
                            //DateTime lastUpdated;

                            //bool isLastEnteredValid = DateTime.TryParse(dgviQor_inbound.Rows[i].Cells[41].Value.ToString(), out lastEntered);
                            //bool isLastUpdatedValid = DateTime.TryParse(dgviQor_inbound.Rows[i].Cells[42].Value.ToString(), out lastUpdated);

                            /*if (!isLastUpdatedValid && isLastEnteredValid)
                            {
                                cmd.Parameters.AddWithValue("@lastUpdated", lastEntered);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@lastUpdated", isLastUpdatedValid ? (object)lastUpdated : DBNull.Value);
                            }

                            cmd.Parameters.AddWithValue("@lastEntered", isLastEnteredValid ? (object)lastEntered : DBNull.Value);*/
                            DateTime shippedDateValue;
                            if (DateTime.TryParse(dgviQor_inbound.Rows[i].Cells[38].Value.ToString(), out shippedDateValue))
                            {
                                if (shippedDateValue == DateTime.Parse("1900-01-01 00:00:00.000"))
                                {
                                    shippedDateValue = new DateTime(1753, 1, 1);
                                }
                                cmd.Parameters.AddWithValue("@shippedDate", shippedDateValue);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@shippedDate", DBNull.Value);
                            }
                            cmd.ExecuteNonQuery();
                        }
                        string typenameValue = dgviQor_inbound.Rows[i].Cells[14].Value.ToString();
                        string jnumValue = dgviQor_inbound.Rows[i].Cells[32].Value.ToString();
                        if (typenameValue == "Desktop" || typenameValue == "Monitor" || typenameValue == "Thin Client")
                        {
                            using (SqlCommand idxCmd = new SqlCommand("SELECT p.idx, p.macAddress FROM products p WHERE p.jnum = @jnum", con))
                            {
                                idxCmd.Parameters.AddWithValue("@jnum", jnumValue);
                                using (SqlDataReader reader = idxCmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        int foundIdx = reader.GetInt32(0);
                                        string foundMacAddress = reader.IsDBNull(1) ? null : reader.GetString(1);

                                        using (SqlCommand updateCmd = new SqlCommand("UPDATE iQor_inbound_T SET productsidx = @idx, macAddress = @macAddress WHERE jnum = @jnum", con))
                                        {
                                            updateCmd.Parameters.AddWithValue("@jnum", jnumValue);
                                            updateCmd.Parameters.AddWithValue("@idx", foundIdx);
                                            updateCmd.Parameters.AddWithValue("@macAddress", foundMacAddress);
                                            updateCmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    MessageBox.Show("RECORDS SUCCESSFULLY SAVED.", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}