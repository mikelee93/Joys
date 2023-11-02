using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;


namespace iQor_System
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

            // 1. DataGridView의 EditMode 설정
            dgviQorSystem.EditMode = DataGridViewEditMode.EditOnEnter;

            // 2. CellValueChanged 이벤트 핸들러 등록
            dgviQorSystem.CellValueChanged += DgviQorSystem_CellValueChanged;
        }

        public void Loadrecords()
        {
            dgviQorSystem.Rows.Clear();
            int i = 0;
            con.Open();
            cmd = new SqlCommand("SELECT lotnumber, typename, jnum, snum, qty, trackingnumber, shippedDate, returnQty, returnTracking, returnedDate, condition, repairable FROM IQor_T", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;

                dgviQorSystem.Rows.Add(i, dr["lotnumber"].ToString(),
                    dr["typename"].ToString(),
                    dr["jnum"].ToString(),
                    dr["snum"].ToString(),
                    dr["qty"].ToString(),
                    dr["trackingnumber"].ToString(),
                    dr["shippedDate"].ToString(),
                    dr["returnQty"].ToString(),
                    dr["returnTracking"].ToString(),
                    dr["returnedDate "].ToString(),
                    dr["condition"].ToString(),
                    dr["repairable"].ToString());
            }
            dr.Close();
            con.Close();
        }
        private void DgviQorSystem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;
            string columnName = dgviQorSystem.Columns[colIndex].Name;

            if (new[] { "returnQty", "returnTracking", "returnedDate", "condition", "repairable" }.Contains(columnName))
            {
                object newValue = dgviQorSystem.Rows[rowIndex].Cells[colIndex].Value;

                if (newValue == null || string.IsNullOrEmpty(newValue.ToString()))
                    return;

                try
                {
                    con.Open();
                    cmd = new SqlCommand($@"UPDATE IQor_T SET 
                            {columnName} = @updatedValue 
                            WHERE lotnumber = @originalLotnumber", con);

                    cmd.Parameters.AddWithValue("@originalLotnumber", dgviQorSystem.Rows[rowIndex].Cells["lotnumber"].Value.ToString());


                    switch (columnName)
                    {
                        case "returnQty":
                            cmd.Parameters.AddWithValue("@updatedValue", Convert.ToInt32(newValue));
                            break;
                        case "returneddate":
                            cmd.Parameters.AddWithValue("@updatedValue", Convert.ToDateTime(newValue));
                            break;
                        default: // 나머지 칼럼들 (returnTracking, condition, repairable)은 문자열로 처리
                            cmd.Parameters.AddWithValue("@updatedValue", newValue.ToString());
                            break;
                    }
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }
        private void dgvupdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgviQorSystem.CurrentRow;
            if (row != null)
            {
                string lotnumber = row.Cells["lotnumber"].Value?.ToString();

                string returnQty = txtreturnQty.Text;
                string returnTracking = btnReturnT.Text;
                string returnedDate = dateTimePicker.Value.ToString("yyyy-MM-dd");
                string condition = cbocondition.SelectedItem?.ToString();
                string repairable = cborepairable.SelectedItem?.ToString();

                try
                {
                    con.Open();
                    cmd = new SqlCommand(@"UPDATE IQor_T SET 
                    returnQty = @returnQty, 
                    returnTracking = @returnTracking, 
                    returnedDate = @returnedDate, 
                    condition = @condition, 
                    repairable = @repairable 
                    WHERE lotnumber = @lotnumber", con);

                    cmd.Parameters.AddWithValue("@lotnumber", lotnumber);
                    cmd.Parameters.AddWithValue("@returnQty", returnQty);
                    cmd.Parameters.AddWithValue("@returnTracking", returnTracking);
                    cmd.Parameters.AddWithValue("@returnedDate", returnedDate);
                    cmd.Parameters.AddWithValue("@condition", condition);
                    cmd.Parameters.AddWithValue("@repairable", repairable);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                    MessageBox.Show("RECORDS SUCCESSFULLY UPDATED.", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void dgviQorSystem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgviQorSystem.Rows[e.RowIndex];
                txtreturnQty.Text = row.Cells["returnQty"].Value?.ToString() ?? "";
                txtReturnT.Text = row.Cells["returnTracking"].Value?.ToString() ?? "";

                if (DateTime.TryParse(row.Cells["returnedDate"].Value?.ToString(), out DateTime returnedDate))
                    dateTimePicker.Value = returnedDate;

                cbocondition.SelectedItem = row.Cells["condition"].Value?.ToString() ?? "";
                cborepairable.SelectedItem = row.Cells["repairable"].Value?.ToString() ?? "";

                var lotnumberCell = row.Cells["lotnumber"];
                if (lotnumberCell != null)
                {
                    string lotnumber = lotnumberCell.Value?.ToString();
                }
                else
                {
                    MessageBox.Show("Column named lotnumber cd.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLotnumber_Click(object sender, EventArgs e)
                {
                    string lotnumber = btnLotnumber.Text;
                    SearchAndDisplay("lotnumber", lotnumber);
                }

                private void btnSnum_Click(object sender, EventArgs e)
                {
                    string snum = btnSnum.Text;
                    SearchAndDisplay("snum", snum);
                }

                private void btnReturnT_Click(object sender, EventArgs e)
                {
                    string returnTracking = btnReturnT.Text;
                    SearchAndDisplay("returnTracking", returnTracking);
                }
                private void SearchAndDisplay(string column, string value)
        {
            try
            {
                string query = $"SELECT lotnumber, typename, jnum, snum, qty, trackingnumber, shippedDate, returnQty, returnTracking, returneddate, condition, repairable FROM IQor_T WHERE {column} = @value";

                dgviQorSystem.Rows.Clear();
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@value", value);
                dr = cmd.ExecuteReader();

                int i = 0;
                while (dr.Read())
                {
                    i++;
                    dgviQorSystem.Rows.Add(i,
                        dr["lotnumber"].ToString(),
                        dr["typename"].ToString(),
                        dr["jnum"].ToString(),
                        dr["snum"].ToString(),
                        dr["qty"].ToString(),
                        dr["trackingnumber"].ToString(),
                        dr["shippedDate"].ToString(),
                        dr["returnQty"].ToString(),
                        dr["returnTracking"].ToString(),
                        dr["returneddate"].ToString(),
                        dr["condition"].ToString(),
                        dr["repairable"].ToString());
                }

                if (i == 0)
                {
                    MessageBox.Show($"No data found for the given {column}!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
                {
                    string lotnumber = txtLotnum.Text;
                    SearchAndDisplay("lotnumber", lotnumber);
                }

                private void txtSnum_TextChanged(object sender, EventArgs e)
                {
                    string snum = txtSnum.Text;
                    SearchAndDisplay("snum", snum);
                }

                private void txtReturnT_TextChanged(object sender, EventArgs e)
                {
                    string returnTracking = txtReturnT.Text;
                    SearchAndDisplay("returnTracking", returnTracking);
                }

        private void txtreturnQty_TextChanged(object sender, EventArgs e)
        {
            string returnTracking = txtReturnT.Text;
            if (!string.IsNullOrEmpty(returnTracking)) // 추가: 빈 문자열로 검색되지 않도록
            {
                SearchAndDisplay("returnTracking", returnTracking);
            }
        }

        /*private void cbocoreturnedDate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }*/

        private void cbocondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbocondition.SelectedItem != null) // 아이템이 선택된 경우에만
            {
                string condition = cbocondition.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(condition))
                {
                    SearchAndDisplay("condition", condition);
                }
            }
        }

        private void cborepairable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cborepairable.SelectedItem != null) // 아이템이 선택된 경우에만
            {
                string repairable = cborepairable.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(repairable))
                {
                    SearchAndDisplay("repairable", repairable);
                }
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            string selectedDate = dateTimePicker.Value.ToString("yyyy-MM-dd"); // 날짜 포맷을 DB와 일치시킴
            SearchAndDisplay("returnedDate", selectedDate);
        }
    }
        }