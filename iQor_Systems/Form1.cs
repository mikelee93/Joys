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
using System.Collections;

namespace iQor_Systems
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.ShowCheckBox = true;
            con = new SqlConnection(connectionString);
            iQor_System.MultiSelect = true;
            dateTimePicker1.Value = DateTime.Today;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //GetiQor_Systemrecord();
            //iQor_System.Columns["idx"].Visible = false;
        }

        //string connectionString = @"Data Source=192.168.1.2;Database=testJoy;User Id=sa;Password=lease-return;MultipleActiveResultSets=True;";
        string connectionString = @"Data Source=192.168.1.2;Database=JoyData;User Id=sa;Password=lease-return;MultipleActiveResultSets=True;";

        public int idx;

        private void GetiQor_Systemrecord()
        {
            SqlCommand cmd = new SqlCommand("Select idx, fname, lname, lotnumber, typename, jnum, snum, qty, trackingnumber, shippedDate, returnqty, returntracking, returneddate, condition, repairable, lastUpdated from iQor_T", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            iQor_System.DataSource = dt;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }
        private void ResetFormControls()
        {
            txtLotnum.Clear();
            txtSnum.Clear();
            txtreturnT.Clear();
            txtreturnQ.Clear();
            txtFname.Clear();
            txtLname.Clear();
            txtLotnum.Focus();
            cboCondition.SelectedIndex = -1;
            cboRepairable.SelectedIndex = -1;
        }
        private void iQor_System_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = Convert.ToInt32(iQor_System.SelectedRows[0].Cells[0].Value);
            txtLotnum.Text = iQor_System.SelectedRows[0].Cells[3].Value.ToString();
            txtSnum.Text = iQor_System.SelectedRows[0].Cells[6].Value.ToString();
            txtreturnT.Text = iQor_System.SelectedRows[0].Cells[11].Value.ToString();
            txtreturnQ.Text = iQor_System.SelectedRows[0].Cells[10].Value.ToString();
            txtFname.Text = iQor_System.SelectedRows[0].Cells[1].Value.ToString();
            txtLname.Text = iQor_System.SelectedRows[0].Cells[2].Value.ToString();
            cboCondition.Text = iQor_System.SelectedRows[0].Cells[13].Value.ToString();
            cboRepairable.Text = iQor_System.SelectedRows[0].Cells[14].Value.ToString();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = iQor_System.SelectedRows;
            DataTable dt = new DataTable();

            StringBuilder query = new StringBuilder("SELECT idx, fname, lname, lotnumber, typename, jnum, snum, qty, trackingnumber, shippedDate, returnqty, returntracking, returneddate, condition, repairable FROM iQor_T WHERE ");
            List<string> conditions = new List<string>();

            List<string> updatedLotNumbers = new List<string>();

            int idx = 0;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                foreach (DataGridViewRow row in selectedRows)
                {
                    string lotnumber = row.Cells["lotnumber"].Value.ToString();
                    updatedLotNumbers.Add(lotnumber);

                    string fname = row.Cells["fname"].Value.ToString();
                    string lname = row.Cells["lname"].Value.ToString();

                    conditions.Add($"(fname = @fname{idx} AND lname = @lname{idx})");

                    cmd.Parameters.AddWithValue($"@fname{idx}", fname);
                    cmd.Parameters.AddWithValue($"@lname{idx}", lname);

                    int rowIdx = Convert.ToInt32(row.Cells["idx"].Value);
                    UpdateRow(rowIdx);

                    idx++;
                }

                if (conditions.Count == 0) return;

                query.Append(string.Join(" OR ", conditions));
                cmd.CommandText = query.ToString();

                try
                {
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        dt.Load(sdr);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }

            iQor_System.DataSource = dt;
            MessageBox.Show("RECORDS SUCCESSFULLY UPDATED.", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetFormControls();

            LoadRowsByLotNumbers(updatedLotNumbers);
        }
        private void LoadRowsByLotNumbers(List<string> lotNumbers)
        {
            if (lotNumbers == null || lotNumbers.Count == 0) return;

            var parameters = new List<SqlParameter>();
            var conditions = new StringBuilder();

            for (int i = 0; i < lotNumbers.Count; i++)
            {
                conditions.Append($"@lotnumber{i}");
                parameters.Add(new SqlParameter($"@lotnumber{i}", lotNumbers[i]));

                if (i < lotNumbers.Count - 1)
                {
                    conditions.Append(", ");
                }
            }

            var query = new StringBuilder($"SELECT idx, fname, lname, lotnumber, typename, jnum, snum, qty, trackingnumber, shippedDate, returnqty, returntracking, returneddate, condition, repairable FROM iQor_T WHERE lotnumber IN ({conditions})");

            using (SqlCommand cmd = new SqlCommand(query.ToString(), con))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                DataTable dt = new DataTable();
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();
                iQor_System.DataSource = dt;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO iQor_T VALUES (@fname, @lname, @lotnumber, @snum, @returnQty, @returnTracking, @condition, @repairable)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@lotnumber", txtLotnum.Text);
                cmd.Parameters.AddWithValue("@snum", txtSnum.Text);
                cmd.Parameters.AddWithValue("@returnQty", txtreturnQ.Text);
                cmd.Parameters.AddWithValue("@returnTracking", txtreturnT.Text);
                cmd.Parameters.AddWithValue("@fname", txtFname.Text);
                cmd.Parameters.AddWithValue("@lname", txtLname.Text);
                cmd.Parameters.AddWithValue("@condition", cboCondition.Text);
                cmd.Parameters.AddWithValue("@repairable", cboRepairable.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("RECORDS SUCCESSFULLY INSERTED.", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetiQor_Systemrecord();
                ResetFormControls();

            }
        }

        private void UpdateRow(int idx)
        {
            SqlCommand cmd = new SqlCommand("UPDATE iQor_T SET returnTracking = @returnTracking, returnQty = @returnQty, condition = @condition, returnedDate = @returnedDate, repairable = @repairable, lastUpdated = @lastUpdated WHERE idx = @idx", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@fname", txtFname.Text);
            cmd.Parameters.AddWithValue("@lname", txtLname.Text);
            cmd.Parameters.AddWithValue("@lotnumber", txtLotnum.Text);
            cmd.Parameters.AddWithValue("@snum", txtSnum.Text);
            cmd.Parameters.AddWithValue("@returnQty", txtreturnQ.Text);
            cmd.Parameters.AddWithValue("@returnTracking", txtreturnT.Text);
            cmd.Parameters.AddWithValue("@condition", cboCondition.Text);
            cmd.Parameters.AddWithValue("@repairable", cboRepairable.Text);

            if (dateTimePicker1.Checked)
            {
                DateTime receivedDate = dateTimePicker1.Value;
                cmd.Parameters.AddWithValue("@returnedDate", receivedDate);
                cmd.Parameters.AddWithValue("@lastEntered", receivedDate);
            }
            else
            {
                cmd.Parameters.AddWithValue("@returnedDate", DBNull.Value);
                cmd.Parameters.AddWithValue("@lastEntered", DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@lastUpdated", DateTime.Now);
            cmd.Parameters.AddWithValue("@idx", idx);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private bool IsValid()
        {
            if (txtLotnum.Text == string.Empty)
            {
                MessageBox.Show("lotnum is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string fname = txtFname.Text;
            string lname = txtLname.Text;
            string lotnumber = txtLotnum.Text;
            string snum = txtSnum.Text;
            string returnTracking = txtreturnT.Text;

            if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname))
            {
                MessageBox.Show("Both fname and lname must be provided to perform the search", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadDataWithSearchParameters(lotnumber, snum, returnTracking, fname, lname);
        }

        private void LoadDataWithSearchParameters(string lotnumber, string snum, string returnTracking, string fname, string lname)
        {
            StringBuilder query = new StringBuilder("SELECT idx, fname, lname, lotnumber, typename, jnum, snum, qty, trackingnumber, shippedDate, returnqty, returntracking, returneddate, condition, repairable FROM iQor_T WHERE 1=1");
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(lotnumber))
            {
                query.Append(" AND lotnumber = @lotnumber");
                parameters.Add(new SqlParameter("@lotnumber", lotnumber));
            }

            if (!string.IsNullOrEmpty(snum))
            {
                query.Append(" AND snum = @snum");
                parameters.Add(new SqlParameter("@snum", snum));
            }

            if (!string.IsNullOrEmpty(returnTracking))
            {
                query.Append(" AND returnTracking = @returnTracking");
                parameters.Add(new SqlParameter("@returnTracking", returnTracking));
            }

            if (!string.IsNullOrEmpty(fname) && !string.IsNullOrEmpty(lname))
            {
                query.Append(" AND fname = @fname AND lname = @lname");
                parameters.Add(new SqlParameter("@fname", fname));
                parameters.Add(new SqlParameter("@lname", lname));
            }

            using (SqlCommand cmd = new SqlCommand(query.ToString(), con))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                DataTable dt = new DataTable();
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();
                iQor_System.DataSource = dt;
            }
        }

        private void btnSnum_Click(object sender, EventArgs e)
        {
            string snum = txtSnum.Text;
            if (!string.IsNullOrEmpty(snum))
            {
                StringBuilder query = new StringBuilder("SELECT idx, fname, lname, lotnumber, typename, jnum, snum, qty, trackingnumber, shippedDate, returnqty, returntracking, returneddate, condition, repairable FROM iQor_T WHERE lotnumber IN (SELECT lotnumber FROM iQor_T WHERE snum = @snum)");
                using (SqlCommand cmd = new SqlCommand(query.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@snum", snum);
                    DataTable dt = new DataTable();
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    con.Close();
                    iQor_System.DataSource = dt;
                }
            }
        }

        private void btnreturnT_Click(object sender, EventArgs e)
        {
            string returnTracking = txtreturnT.Text;
            if (!string.IsNullOrEmpty(returnTracking))
            {
                StringBuilder query = new StringBuilder("SELECT idx, fname, lname, lotnumber, typename, jnum, snum, qty, trackingnumber, shippedDate, returnqty, returntracking, returneddate, condition, repairable FROM iQor_T WHERE lotnumber IN (SELECT lotnumber FROM iQor_T WHERE returnTracking = @returnTracking)");
                using (SqlCommand cmd = new SqlCommand(query.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@returnTracking", returnTracking);
                    DataTable dt = new DataTable();
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    con.Close();
                    iQor_System.DataSource = dt;
                }
            }
        }
        private void SearchBy(string columnName, string searchValue)
        {
            StringBuilder query = new StringBuilder("SELECT idx, fname, lname, lotnumber, typename, jnum, snum, qty, trackingnumber, shippedDate, returnqty, returntracking, returneddate, condition, repairable FROM iQor_T WHERE 1=1");

            if (!string.IsNullOrEmpty(columnName) && !string.IsNullOrEmpty(searchValue))
            {
                query.Append($" AND {columnName} LIKE @value");
            }

            using (SqlCommand cmd = new SqlCommand(query.ToString(), con))
            {
                cmd.Parameters.AddWithValue("@value", "%" + searchValue + "%");

                DataTable dt = new DataTable();
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();
                iQor_System.DataSource = dt;
            }
        }
        private void btnLotnum_Click(object sender, EventArgs e)
        {
            string lotnumber = txtLotnum.Text;
            if (!string.IsNullOrEmpty(lotnumber))
            {
                StringBuilder query = new StringBuilder("SELECT idx, fname, lname, lotnumber, typename, jnum, snum, qty, trackingnumber, shippedDate, returnqty, returntracking, returneddate, condition, repairable FROM iQor_T WHERE lotnumber = @lotnumber");
                using (SqlCommand cmd = new SqlCommand(query.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@lotnumber", lotnumber);
                    DataTable dt = new DataTable();
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    con.Close();
                    iQor_System.DataSource = dt;
                }
            }
        }
        private void btnReturnD_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value.Date;

            StringBuilder query = new StringBuilder("SELECT idx, fname, lname, lotnumber, typename, jnum, snum, qty, trackingnumber, shippedDate, returnqty, returntracking, returneddate, condition, repairable FROM iQor_T WHERE returnedDate = @selectedDate");
            using (SqlCommand cmd = new SqlCommand(query.ToString(), con))
            {
                cmd.Parameters.AddWithValue("@selectedDate", selectedDate);

                DataTable dt = new DataTable();
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();
                iQor_System.DataSource = dt;
            }
            ResetFormControls();
        }
    }
}