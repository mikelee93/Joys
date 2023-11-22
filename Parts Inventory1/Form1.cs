using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Microsoft.Office.Interop;

namespace Parts_Inventory1
{
    public partial class Form1 : Form
    {
        SqlConnection con;

        private int currentSelectedIdx = -1;
        public Form1()
        {
            InitializeComponent();
            InitializeComboBox();
            InitializeComboBox1();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.CellClick += dataGridView1_CellClick;
            this.StartPosition = FormStartPosition.CenterScreen;
            cboSelect.SelectedIndexChanged += new EventHandler(selectComboBox_SelectedIndexChanged);
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged_Custom);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateReceived.Format = DateTimePickerFormat.Short;
            dateReceived.ShowUpDown = false;
            dateReceived.Value = DateTime.Today;
            dateTimePicker1.Value = DateTime.Today;
            textBox2.TextChanged += textBox2_TextChanged;
        }
        string connectionString = @"Data Source=;Database=;User Id=;Password=;MultipleActiveResultSets=True;";
        //string connectionString = @"Data Source=;Database=;User Id=;Password=;MultipleActiveResultSets=True;";


        private void cboSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSubN_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSapN_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboSystem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tab_Purchase_Click(object sender, EventArgs e)
        {

        }

        private void tab_Pull_Click(object sender, EventArgs e)
        {
            typeIdx = 0;
        }

        private void cboSelect_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tab_Purchase)
            {
                UpdateControlsBasedOnSelection(cboSelect.SelectedItem?.ToString() ?? string.Empty);
            }
        }
        private void comboBox1_SelectedIndexChanged_Custom(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tab_Pull)
            {
                UpdateComboBox4Items(comboBox1.SelectedItem?.ToString() ?? string.Empty);
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tab_Pull)
            {
                UpdateControlsBasedOnSelection(comboBox1.SelectedItem?.ToString() ?? string.Empty);
            }
        }

        private void UpdateControlsBasedOnSelection(string selectedComponent)
        {
            DisableControlsBasedOnTab();

            cboSubType.Enabled = (selectedComponent == "HDD" || selectedComponent == "ODD");

            switch (selectedComponent)
            {
                case "CPU":
                    typeIdx = 11;
                    if (tabControl1.SelectedTab == tab_Purchase)
                    {
                        txttypeSize.Enabled = false;
                        cboSystem.Enabled = true;
                    }
                    else if (tabControl1.SelectedTab == tab_Pull)
                    {
                        textBox5.Enabled = false;
                    }
                    break;
                case "RAM":
                    typeIdx = 12;
                    if (tabControl1.SelectedTab == tab_Purchase)
                    {
                        cboSystem.Enabled = true;
                        cboramType.Enabled = true;
                        cboEcc.Enabled = true;
                        txtramSize.Enabled = true;
                        txtSpeed.Enabled = true;
                        txttypeSize.Enabled = false;
                    }
                    else if (tabControl1.SelectedTab == tab_Pull)
                    {
                        comboBox3.Enabled = true;
                        textBox5.Enabled = false;
                    }
                    break;
                case "HDD":
                    typeIdx = 13;
                    txttypeSize.Enabled = true;
                    break;
                case "ODD":
                    typeIdx = 14;
                    if (tabControl1.SelectedTab == tab_Purchase)
                    {
                        cboSystem.Enabled = false;
                        txttypeSize.Enabled = true;
                    }
                    else if (tabControl1.SelectedTab == tab_Pull)
                    {
                        comboBox3.Enabled = false;
                    }
                    break;
                default:
                    typeIdx = 0;
                    cboSubType.Enabled = false;
                    break;
            }
        }

        private void DisableControlsBasedOnTab()
        {
            if (tabControl1.SelectedTab == tab_Purchase)
            {
                cboSystem.Enabled = false;
                cboramType.Enabled = false;
                cboEcc.Enabled = false;
                txtramSize.Enabled = false;
                txtSpeed.Enabled = false;
                txttypeSize.Enabled = false;
            }
            else if (tabControl1.SelectedTab == tab_Pull)
            {
                comboBox3.Enabled = false;
                comboBox6.Enabled = false;
                comboBox7.Enabled = false;
                textBox6.Enabled = false;
                textBox1.Enabled = false;
                textBox5.Enabled = false;
            }
        }

        private int typeIdx = 2;
        private void cboSystem_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedComponent = cboSelect.SelectedItem?.ToString() ?? string.Empty;
            string selectedSystemValue = cboSystem.SelectedItem?.ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(selectedSystemValue))
            {
                return;
            }

            if (selectedComponent == "RAM")
            {
                string query;
                if (selectedSystemValue == "SYSTEM DT")
                {
                    query = "SELECT * FROM TypeSizeRam_New WHERE FormFactor = 'DIMM'";
                }
                else if (selectedSystemValue == "LAPTOP LT")
                {
                    query = "SELECT * FROM TypeSizeRam_New WHERE FormFactor = 'SoDIMM'";
                }
                else
                {
                    return;
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView1.DataSource = dt;
                    }
                    con.Close();
                }
            }
            else
            {
                typeIdx = selectedSystemValue == "SYSTEM DT" ? 2 : selectedSystemValue == "LAPTOP LT" ? 3 : 0;

                if (typeIdx == 0) return;

                string query = $@"SELECT * FROM subType
                WHERE typeIdx = {typeIdx} ORDER BY subTypeName;";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView1.DataSource = dt;
                    }
                    con.Close();
                }
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            if (!dataGridView1.Columns.Contains("idx"))
            {
                MessageBox.Show("The 'idx' column was not found.", "Column Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

            object idxCellValue = selectedRow.Cells["idx"].Value;
            if (idxCellValue != null && int.TryParse(idxCellValue.ToString(), out int idx))
            {
                currentSelectedIdx = idx;
            }
            else
            {
                MessageBox.Show("The 'idx' value is not valid.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            string value = selectedRow.Cells[columnName].Value?.ToString() ?? string.Empty;

            switch (columnName)
            {
                case "sapNum":
                    txtSap.Text = value;
                    break;
                case "typeSizeName":
                    txtCompo.Text = value;
                    textBox2.Text = value;
                    break;
                case "ramType":
                    if (tabControl1.SelectedTab == tab_Pull)
                    {
                        comboBox6.SelectedItem = value;
                    }
                    break;
                case "ecc":
                    if (tabControl1.SelectedTab == tab_Pull)
                    {
                        comboBox7.SelectedItem = value;
                    }
                    break;
                case "ramSize":
                    if (tabControl1.SelectedTab == tab_Purchase)
                    {
                        txtramSize.Text = value;
                    }
                    else if (tabControl1.SelectedTab == tab_Pull)
                    {
                        textBox6.Text = value;
                    }
                    break;
                case "speed":
                    string speedValue = selectedRow.Cells["speed"].Value?.ToString() ?? string.Empty;
                    string moduleValue = selectedRow.Cells["module"].Value?.ToString() ?? string.Empty;

                    if (tabControl1.SelectedTab == tab_Purchase)
                    {
                        txtSpeed.Text = speedValue;
                        txtCompo.Text = moduleValue;
                    }
                    else if (tabControl1.SelectedTab == tab_Pull)
                    {
                        textBox1.Text = speedValue;
                        textBox2.Text = moduleValue;
                    }
                    break;
                case "typeSizeHddName":
                        currentSelectedIdx = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["idx"].Value);

                        string typeSizeHddNameValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        var numberMatch = System.Text.RegularExpressions.Regex.Match(typeSizeHddNameValue, @"\d+");
                        if (tabControl1.SelectedTab == tab_Purchase)
                        {
                            textBox5.Text = numberMatch.Success ? numberMatch.Value : string.Empty;
                            if (dataGridView1.Columns.Contains("diskCapacity"))
                            {
                                string diskCapacityValue = dataGridView1.Rows[e.RowIndex].Cells["diskCapacity"].Value?.ToString() ?? string.Empty;
                                txtCompo.Text = diskCapacityValue;
                            }
                        }
                        else if (tabControl1.SelectedTab == tab_Pull)
                        {
                            textBox5.Text = numberMatch.Success ? numberMatch.Value : string.Empty;
                            if (dataGridView1.Columns.Contains("diskCapacity"))
                            {
                                string diskCapacityValue = dataGridView1.Rows[e.RowIndex].Cells["diskCapacity"].Value?.ToString() ?? string.Empty;
                                textBox2.Text = diskCapacityValue;
                            }
                        }
                        break;
                    case "typeSizeOddName":
                        currentSelectedIdx = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["idx"].Value);

                        if (tabControl1.SelectedTab == tab_Purchase)
                        {
                            txtCompo.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        }
                        else if (tabControl1.SelectedTab == tab_Pull)
                        {
                            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        }
                        break;
                    }
                }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string sapText = txtSap.Text;
            string dtltText = textBox2.Text;
            string qtyText = textBox3.Text;
            string compoText = txtCompo.Text;
            string inoutText = comboBox2.SelectedItem?.ToString();

            if ((tabControl1.SelectedTab == tab_Purchase && (string.IsNullOrWhiteSpace(cboInout.Text) || string.IsNullOrWhiteSpace(txtQty.Text) || string.IsNullOrWhiteSpace(txtSap.Text))) ||
    (tabControl1.SelectedTab == tab_Pull && (string.IsNullOrWhiteSpace(comboBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))))
            {
                MessageBox.Show("There are empty fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var lastEntered = DateTime.Now;
            int typeIdx = GetTypeIdxFromSelectedComponent();
            int enterIdx;
            string inout;
            int qty;

            DateTime enteredDate = tabControl1.SelectedTab == tab_Purchase ? dateReceived.Value.Date : dateTimePicker1.Value.Date;

            if (tabControl1.SelectedTab == tab_Purchase)
            {
                enterIdx = GetEnterIdxFromSapNum(txtSap.Text);
                inout = cboInout.SelectedItem?.ToString();
                qty = int.Parse(txtQty.Text);
            }
            else
            {
                enterIdx = 0;
                inout = comboBox2.SelectedItem?.ToString();
                qty = int.Parse(textBox3.Text);
            }

            int componentIdx = currentSelectedIdx;
            if (currentSelectedIdx == -1)
            {
                MessageBox.Show("componentIdx 값을 선택해주세요.", "값 누락", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"
            DECLARE @NewID INT;
            INSERT INTO component_T (typeIdx, enterIdx, componentIdx, enteredDate, inout, qty, lastEntered) 
            VALUES (@typeIdx, @enterIdx, @componentIdx, @enteredDate, @inout, @qty, @lastEntered);
            SET @NewID = SCOPE_IDENTITY();
            SELECT * FROM component_T WHERE idx = @NewID;";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@typeIdx", typeIdx);
                        cmd.Parameters.AddWithValue("@enterIdx", enterIdx);
                        cmd.Parameters.AddWithValue("@componentIdx", componentIdx);
                        cmd.Parameters.AddWithValue("@enteredDate", enteredDate);
                        cmd.Parameters.AddWithValue("@inout", inout);
                        cmd.Parameters.AddWithValue("@qty", qty);
                        cmd.Parameters.AddWithValue("@lastEntered", lastEntered);

                        var newId = (int)cmd.ExecuteScalar();

                        if (newId > 0)
                        {
                            MessageBox.Show("Successfully inserted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshDataGridView(newId);
                        }
                        else
                        {
                            MessageBox.Show("No data was inserted.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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
        }

        private void RefreshDataGridView(int newId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM component_T WHERE idx = @newId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@newId", newId);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
                con.Close();
            }
        }
        private void LoadDataToDataGridView()
        {
            string query = "SELECT * FROM component_T ORDER BY enteredDate ASC";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
                con.Close();
            }
        }

        private int GetTypeIdxFromSelectedComponent()
        {
            string selectedComponent;
            if (tabControl1.SelectedTab == tab_Purchase)
            {
                selectedComponent = cboSelect.SelectedItem?.ToString() ?? string.Empty;
            }
            else if (tabControl1.SelectedTab == tab_Pull)
            {
                selectedComponent = comboBox1.SelectedItem?.ToString() ?? string.Empty;
            }
            else
            {
                return 0;
            }

            switch (selectedComponent)
            {
                case "CPU": return 11;
                case "RAM": return 12;
                case "HDD": return 13;
                case "ODD": return 14;
                default: return 0;
            }
        }

        private int GetEnterIdxFromSapNum(string sapNum)
        {
            int enterIdx = 0;
            string query = "SELECT idx FROM Sap WHERE sapNum LIKE @sapNum";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@sapNum", "%" + sapNum + "%");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            enterIdx = reader.GetInt32(reader.GetOrdinal("idx"));
                        }
                    }
                }
                con.Close();
            }
            return enterIdx;
        }

        private int GetComponentIdxFromComponent(string componentValue)
        {
            int componentIdx = 0;
            string query = "SELECT idx FROM TypeSize WHERE typeIdx = @typeIdx AND typeSizeName LIKE @componentValue";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@typeIdx", typeIdx);
                    cmd.Parameters.AddWithValue("@componentValue", $"%{componentValue}%");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            componentIdx = reader.GetInt32(reader.GetOrdinal("idx"));
                        }
                    }
                }
                con.Close();
            }
            return componentIdx;
        }

        private void txtCompo_TextChanged(object sender, EventArgs e)
        {
            string inputText = txtCompo.Text;

            if (!string.IsNullOrEmpty(inputText) && typeIdx != 0)
            {
                string query = $"SELECT * FROM TypeSize WHERE typeIdx = {typeIdx} AND typeSizeName LIKE '%{inputText}%'";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView1.DataSource = dt;
                    }
                    con.Close();
                }
            }
        }
        

        private void LoadData(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                con.Close();
            }
        }

        private void txtSap_TextChanged(object sender, EventArgs e)
        {
            string inputText = txtSap.Text;

            if (!string.IsNullOrEmpty(inputText))
            {
                string query = $@"
                SELECT DISTINCT Sap.idx, Sap.sapNum, sapDate, lastentered
                FROM Sap
                JOIN sapdetail ON Sap.idx = sapdetail.sapidx
                JOIN Type ON sapdetail.typeIdx = Type.idx
                WHERE Sap.lastentered >= DATEADD(MONTH, -3, CAST(GETDATE() AS DATE))
                AND (Type.typeName = 'component' OR Type.idx = 6)
                AND Sap.sapNum LIKE '%{inputText}%';";

                LoadData(query);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCompo.Clear();
            textBox2.Clear();

            if (tabControl1.SelectedTab == tab_Purchase)
            {
                cboSelect.SelectedIndex = -1;
                cboSystem.SelectedIndex = -1;
                cboInout.SelectedIndex = -1;
                txtQty.Clear();
                txtSap.Clear();
                cboEcc.SelectedIndex = -1;
                cboramType.SelectedIndex = -1;
                txtramSize.Clear();
                txtSpeed.Clear();
                cboSubType.SelectedIndex = -1;
                txttypeSize.Clear();
            }
            else if (tabControl1.SelectedTab == tab_Pull)
            {
                comboBox1.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                textBox3.Clear();
                comboBox6.SelectedIndex = -1;
                comboBox7.SelectedIndex = -1;
                textBox6.Clear();
                textBox1.Clear();
                comboBox4.SelectedIndex = -1;
                textBox5.Clear();
            }

            dataGridView1.ClearSelection();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select a row to update.");
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int selectedRowIdx = Convert.ToInt32(selectedRow.Cells["idx"].Value);

            string inout;
            int qty;
            DateTime enteredDate;

            if (tabControl1.SelectedTab == tab_Purchase)
            {
                inout = cboInout.SelectedItem.ToString();
                qty = Convert.ToInt32(txtQty.Text);
                enteredDate = dateReceived.Value.Date;
            }
            else if (tabControl1.SelectedTab == tab_Pull)
            {
                inout = comboBox2.SelectedItem.ToString();
                qty = Convert.ToInt32(textBox3.Text);
                enteredDate = dateTimePicker1.Value.Date;
            }
            else
            {
                MessageBox.Show("Please select either the Purchase or Pull Out tab.");
                return;
            }

            string updateQuery = @"
            UPDATE component_T
            SET 
                inout = @inout,
                qty = @qty, 
                enteredDate = @enteredDate
            WHERE 
                idx = @idx";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@inout", inout);
                        cmd.Parameters.AddWithValue("@qty", qty);
                        cmd.Parameters.AddWithValue("@enteredDate", enteredDate);
                        cmd.Parameters.AddWithValue("@idx", selectedRowIdx);

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("The record has been updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No record was updated.");
                        }
                    }
                }

                LoadDataFromDatabase(selectedRowIdx);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void LoadDataFromDatabase(int idx)
        {
            string query = "SELECT * FROM component_T WHERE idx = @idx";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@idx", idx);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure to delete this item?",
                                                    "Confirm Delete",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    var selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells["idx"].Value != null)
                    {
                        int idx = (int)selectedRow.Cells["idx"].Value;
                        string query = "DELETE FROM component_T WHERE idx = @idx;";

                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            try
                            {
                                con.Open();
                                using (SqlCommand cmd = new SqlCommand(query, con))
                                {
                                    cmd.Parameters.AddWithValue("@idx", idx);
                                    int result = cmd.ExecuteNonQuery();

                                    if (result > 0)
                                    {
                                        dataGridView1.Rows.Remove(selectedRow);
                                        MessageBox.Show("Deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
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
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Select Row", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime searchDate = tabControl1.SelectedTab == tab_Purchase ? dateReceived.Value.Date : dateTimePicker1.Value.Date;

            string query = @"
            SELECT * 
            FROM component_T 
            WHERE CONVERT(DATE, enteredDate) = @searchDate
            ORDER BY enteredDate asc;";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@searchDate", searchDate);

                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        dataGridView1.DataSource = dt;
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
        }

        private int GetTypeIdxFromSystemSelection()
        {
            string selectedSystem = comboBox3.SelectedItem?.ToString() ?? string.Empty;
            switch (selectedSystem)
            {
                case "SYSTEM DT":
                    return 2;
                case "LAPTOP LT":
                    return 3;
                default:
                    return 0;
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            bool isPullOutTabSelected = tabControl1.SelectedTab == tab_Pull;

            if (isPullOutTabSelected)
            {
                string inputText = textBox2.Text;

                if (!string.IsNullOrEmpty(inputText))
                {
                    int typeIdx = GetTypeIdxFromSystemSelection();

                    string query = $"SELECT * FROM TypeSize WHERE typeIdx = {typeIdx} AND typeSizeName LIKE '%{inputText}%'";

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            dataGridView1.DataSource = dt;
                        }
                        con.Close();
                    }
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tab_Pull)
            {
                string selectedComponent = comboBox1.SelectedItem?.ToString() ?? string.Empty;
                UpdateControlsForPullTab(selectedComponent);
            }
        }

        private void UpdateControlsForPullTab(string selectedComponent)
        {
            ResetControlsForPullTab();

            switch (selectedComponent)
            {
                case "CPU":
                    comboBox3.Enabled = true; // DT/LT 
                    comboBox4.Enabled = false; // SubType 
                    textBox5.Enabled = false;
                    break;
                case "RAM":
                    comboBox3.Enabled= true;
                    comboBox6.Enabled = true; // ramType 
                    comboBox7.Enabled = true; // ECC 
                    textBox6.Enabled = true;  // ramSize 
                    textBox1.Enabled = true;  // Speed 
                    comboBox4.Enabled = false; 
                    textBox5.Enabled = false;
                    break;
                case "HDD":
                    textBox5.Enabled= true;
                    comboBox4.Enabled = true;
                    break;
                case "ODD":
                    textBox5.Enabled = true;
                    comboBox4.Enabled = true;
                    break;
            }
        }

        private void ResetControlsForPullTab()
        {
            comboBox3.Enabled = false;
            comboBox6.Enabled = false;
            comboBox7.Enabled = false;
            textBox6.Enabled = false;
            textBox1.Enabled = false;
            comboBox4.Enabled = false;
        }

        private void cboramType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRamType = tabControl1.SelectedTab == tab_Purchase ? cboramType.SelectedItem?.ToString() : comboBox6.SelectedItem?.ToString();
            string selectedSystemValue = cboSystem.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedRamType))
            {
                return;
            }

            string formFactor = selectedSystemValue == "SYSTEM DT" ? "DIMM" : "SoDIMM";
            string query = $"SELECT * FROM TypeSizeRam_New WHERE FormFactor = '{formFactor}' AND RamType = '{selectedRamType}'";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
                con.Close();
            }
        }

        private void cboEcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedEccValue = tabControl1.SelectedTab == tab_Purchase ? cboEcc.SelectedItem?.ToString() : comboBox7.SelectedItem?.ToString();
            string selectedRamType = tabControl1.SelectedTab == tab_Purchase ? cboramType.SelectedItem?.ToString() : comboBox6.SelectedItem?.ToString();
            string selectedSystemValue = cboSystem.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedEccValue))
            {
                return;
            }

            string formFactor = selectedSystemValue == "SYSTEM DT" ? "DIMM" : "SoDIMM";
            string query = $"SELECT * FROM TypeSizeRam_New WHERE FormFactor = '{formFactor}' AND ecc = '{selectedEccValue}' AND RamType = '{selectedRamType}'";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
                con.Close();
            }
        }

        private void txtramSize_TextChanged(object sender, EventArgs e)
        {
            string inputText = txtramSize.Text;

            string selectedEccValue = cboEcc.SelectedItem?.ToString() ?? string.Empty;
            string selectedRamType = cboramType.SelectedItem?.ToString() ?? string.Empty;
            string selectedSystemValue = cboSystem.SelectedItem?.ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(inputText) || string.IsNullOrEmpty(selectedEccValue) || string.IsNullOrEmpty(selectedRamType) || string.IsNullOrEmpty(selectedSystemValue))
            {
                return;
            }

            string formFactor = selectedSystemValue == "SYSTEM DT" ? "DIMM" : "SoDIMM";
            string query = $@"SELECT * FROM TypeSizeRam_New 
            WHERE FormFactor = '{formFactor}' 
            AND RamType = '{selectedRamType}' 
            AND Ecc = '{selectedEccValue}' 
            AND ramSize LIKE '%{inputText}%' 
            ORDER BY CAST(speed AS INT) asc";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
                con.Close();
            }
        }

        private void txtSpeed_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedComponent = comboBox3.SelectedItem?.ToString() ?? string.Empty;
            string selectedSystemValue = comboBox3.SelectedItem?.ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(selectedSystemValue))
            {
                return;
            }

            if (selectedComponent == "RAM")
            {
                string query;
                if (selectedSystemValue == "SYSTEM DT")
                {
                    query = "SELECT * FROM TypeSizeRam_New WHERE FormFactor = 'DIMM'";
                }
                else if (selectedSystemValue == "LAPTOP LT")
                {
                    query = "SELECT * FROM TypeSizeRam_New WHERE FormFactor = 'SoDIMM'";
                }
                else
                {
                    return;
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView1.DataSource = dt;
                    }
                    con.Close();
                }
            }
            else
            {
                typeIdx = selectedSystemValue == "SYSTEM DT" ? 2 : selectedSystemValue == "LAPTOP LT" ? 3 : 0;

                if (typeIdx == 0) return;

                string query = $@"SELECT * FROM subType
                WHERE typeIdx = {typeIdx} ORDER BY subTypeName;";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView1.DataSource = dt;
                    }
                    con.Close();
                }
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tab_Pull)
            {
                UpdateDataGridViewForPullTab();
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tab_Pull)
            {
                UpdateDataGridViewForPullTab();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tab_Pull)
            {
                UpdateDataGridViewForPullTab();
            }
        }

        private void UpdateDataGridViewForPullTab()
        {
            string selectedRamType = comboBox6.SelectedItem?.ToString();
            string selectedEccValue = comboBox7.SelectedItem?.ToString();
            string ramSizeInput = textBox6.Text;
            string selectedSystemValue = comboBox3.SelectedItem?.ToString();

            string formFactor = selectedSystemValue == "SYSTEM DT" ? "DIMM" : "SoDIMM";
            string query = $@"SELECT * FROM TypeSizeRam_New 
                      WHERE FormFactor = '{formFactor}'";

            if (!string.IsNullOrEmpty(selectedRamType))
            {
                query += $" AND RamType = '{selectedRamType}'";
            }

            if (!string.IsNullOrEmpty(selectedEccValue))
            {
                query += $" AND ecc = '{selectedEccValue}'";
            }

            if (!string.IsNullOrEmpty(ramSizeInput))
            {
                query += $" AND ramSize LIKE '%{ramSizeInput}%'";
            }

            query += " ORDER BY CAST(speed AS INT) asc";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
                con.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime searchDate = tabControl1.SelectedTab == tab_Purchase ? dateReceived.Value.Date : dateTimePicker1.Value.Date;

            string query = @"
            SELECT * 
            FROM component_T 
            WHERE CONVERT(DATE, enteredDate) = @searchDate
            ORDER BY enteredDate asc;";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@searchDate", searchDate);

                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        dataGridView1.DataSource = dt;
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
        }
        private void InitializeComboBox()
        {
            cboSubType.Items.Clear();

            cboSubType.Items.Add(new { Text = "1. HDD/3.5", Value = 1 });
            cboSubType.Items.Add(new { Text = "2. HDD/2.5", Value = 2 });
            cboSubType.Items.Add(new { Text = "3. HDD/1.8", Value = 3 });
            cboSubType.Items.Add(new { Text = "4. SSD/2.5", Value = 4 });
            cboSubType.Items.Add(new { Text = "5. SSD/1.8", Value = 5 });
            cboSubType.Items.Add(new { Text = "6. M2SATA/1.8", Value = 6 });
            cboSubType.Items.Add(new { Text = "7. M2NVMe/1.8", Value = 7 });
            cboSubType.Items.Add(new { Text = "8. eMMC/1.8", Value = 8 });
            cboSubType.Items.Add(new { Text = "9. MSATA/1.8", Value = 9 });
            cboSubType.Items.Add(new { Text = "1. Regular", Value = 12 });
            cboSubType.Items.Add(new { Text = "2. Slim", Value = 13 });

            cboSubType.DisplayMember = "Text";
            cboSubType.ValueMember = "Value";
        }

        private void cboSubType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cboSubType.Enabled || cboSubType.SelectedIndex < 0)
                return;

            string query = "";
            if (typeIdx == 13)
            {
                int subTypeIdx = Convert.ToInt32(((dynamic)cboSubType.SelectedItem).Value);
                query = $"SELECT * FROM TypeSizeHdd_T WHERE subTypeHddIdx = {subTypeIdx};";
            }
            else if (typeIdx == 14)
            {
                var selectedItem = (dynamic)cboSubType.SelectedItem;
                int subTypeIdx = Convert.ToInt32(selectedItem.Value);

                query = subTypeIdx == 12 ?
                        "SELECT * FROM TypeSizeOdd_T WHERE subTypeOddIdx = 1;" :
                        subTypeIdx == 13 ?
                        "SELECT * FROM TypeSizeOdd_T WHERE subTypeOddIdx = 2;" :
                        $"SELECT * FROM TypeSizeOdd_T WHERE subTypeOddIdx = {subTypeIdx};";
            }

            if (!string.IsNullOrEmpty(query))
            {
                UpdateDataGridView(query);
            }
        }

        private void txttypeSize_TextChanged(object sender, EventArgs e)
        {
            string inputText = txttypeSize.Text;
            string selectedSubTypeIdx = cboSubType.SelectedItem?.ToString() ?? string.Empty;

            if (!string.IsNullOrEmpty(inputText) && !string.IsNullOrEmpty(selectedSubTypeIdx))
            {
                string query = $@"SELECT * FROM TypeSizeHdd_T 
                          WHERE subTypeHddIdx = {selectedSubTypeIdx} 
                          AND typeSizeHddName LIKE '%{inputText}%'
                          ORDER BY idx";

                UpdateDataGridView(query);
            }
        }

        private void UpdateDataGridView(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                con.Close();
            }
        }
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        private void selectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboSubType.Items.Clear();

            if (cboSelect.SelectedItem.ToString() == "HDD")
            {
                cboSubType.Items.Add(new ComboBoxItem { Text = "1. HDD/3.5", Value = 1 });
                cboSubType.Items.Add(new ComboBoxItem { Text = "2. HDD/2.5", Value = 2 });
                cboSubType.Items.Add(new ComboBoxItem { Text = "3. HDD/1.8", Value = 3 });
                cboSubType.Items.Add(new ComboBoxItem { Text = "4. SSD/2.5", Value = 4 });
                cboSubType.Items.Add(new ComboBoxItem { Text = "5. SSD/1.8", Value = 5 });
                cboSubType.Items.Add(new ComboBoxItem { Text = "6. M2SATA/1.8", Value = 6 });
                cboSubType.Items.Add(new ComboBoxItem { Text = "7. M2NVMe/1.8", Value = 7 });
                cboSubType.Items.Add(new ComboBoxItem { Text = "8. eMMC/1.8", Value = 8 });
                cboSubType.Items.Add(new ComboBoxItem { Text = "9. MSATA/1.8", Value = 9 });
            }
            else if (cboSelect.SelectedItem.ToString() == "ODD")
            {
                cboSubType.Items.Add(new ComboBoxItem { Text = "1. Regular", Value = 12 });
                cboSubType.Items.Add(new ComboBoxItem { Text = "2. Slim", Value = 13 });
            }

            cboSubType.DisplayMember = "Text";
            cboSubType.ValueMember = "Value";
        }

        private void InitializeComboBox1()
        {
            comboBox4.Items.Clear();

            comboBox4.Items.Add(new ComboBoxItem { Text = "1. HDD/3.5", Value = 1 });
            comboBox4.Items.Add(new ComboBoxItem { Text = "2. HDD/2.5", Value = 2 });
            comboBox4.Items.Add(new ComboBoxItem { Text = "3. HDD/1.8", Value = 3 });
            comboBox4.Items.Add(new ComboBoxItem { Text = "4. SSD/2.5", Value = 4 });
            comboBox4.Items.Add(new ComboBoxItem { Text = "5. SSD/1.8", Value = 5 });
            comboBox4.Items.Add(new ComboBoxItem { Text = "6. M2SATA/1.8", Value = 6 });
            comboBox4.Items.Add(new ComboBoxItem { Text = "7. M2NVMe/1.8", Value = 7 });
            comboBox4.Items.Add(new ComboBoxItem { Text = "8. eMMC/1.8", Value = 8 });
            comboBox4.Items.Add(new ComboBoxItem { Text = "9. MSATA/1.8", Value = 9 });
            comboBox4.Items.Add(new ComboBoxItem { Text = "1. Regular", Value = 12 });
            comboBox4.Items.Add(new ComboBoxItem { Text = "2. Slim", Value = 13 });

            comboBox4.DisplayMember = "Text";
            comboBox4.ValueMember = "Value";
        }

        private void UpdateComboBox4Items(string selectedComponent)
        {
            comboBox4.Items.Clear();

            if (selectedComponent == "HDD")
            {
                comboBox4.Items.Add(new ComboBoxItem { Text = "1. HDD/3.5", Value = 1 });
                comboBox4.Items.Add(new ComboBoxItem { Text = "2. HDD/2.5", Value = 2 });
                comboBox4.Items.Add(new ComboBoxItem { Text = "3. HDD/1.8", Value = 3 });
                comboBox4.Items.Add(new ComboBoxItem { Text = "4. SSD/2.5", Value = 4 });
                comboBox4.Items.Add(new ComboBoxItem { Text = "5. SSD/1.8", Value = 5 });
                comboBox4.Items.Add(new ComboBoxItem { Text = "6. M2SATA/1.8", Value = 6 });
                comboBox4.Items.Add(new ComboBoxItem { Text = "7. M2NVMe/1.8", Value = 7 });
                comboBox4.Items.Add(new ComboBoxItem { Text = "8. eMMC/1.8", Value = 8 });
                comboBox4.Items.Add(new ComboBoxItem { Text = "9. MSATA/1.8", Value = 9 });
            }
            else if (selectedComponent == "ODD")
            {
                comboBox4.Items.Add(new ComboBoxItem { Text = "1. Regular", Value = 12 });
                comboBox4.Items.Add(new ComboBoxItem { Text = "2. Slim", Value = 13 });
            }

            comboBox4.DisplayMember = "Text";
            comboBox4.ValueMember = "Value";

            if (comboBox4.Items.Count > 0)
                comboBox4.SelectedIndex = 0;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tab_Pull)
            {
                if (!comboBox4.Enabled || comboBox4.SelectedIndex < 0)
                    return;

                var selectedItem = comboBox4.SelectedItem as ComboBoxItem;
                if (selectedItem == null)
                {
                    MessageBox.Show("Please select a valid subtype.");
                    return;
                }

                int subTypeIdx = Convert.ToInt32(selectedItem.Value);
                string selectedComponent = comboBox1.SelectedItem?.ToString() ?? string.Empty;
                string query = "";

                if (selectedComponent == "HDD")
                {
                    query = $"SELECT * FROM TypeSizeHdd_T WHERE subTypeHddIdx = {subTypeIdx};";
                }
                else if (selectedComponent == "ODD")
                {
                    query = subTypeIdx == 12 ?
                        "SELECT * FROM TypeSizeOdd_T WHERE subTypeOddIdx = 1;" :
                        subTypeIdx == 13 ?
                        "SELECT * FROM TypeSizeOdd_T WHERE subTypeOddIdx = 2;" :
                        $"SELECT * FROM TypeSizeOdd_T WHERE subTypeOddIdx = {subTypeIdx};";
                }

                if (!string.IsNullOrEmpty(query))
                {
                    UpdateDataGridView(query);
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string inputText = textBox5.Text;
            string selectedSubTypeIdx = comboBox4.SelectedItem?.ToString() ?? string.Empty;

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!");
                return;
            }

            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet xlWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);

            for (int j = 0; j < dataGridView1.Columns.Count; j++)
            {
                xlWorksheet.Cells[1, j + 1] = dataGridView1.Columns[j].HeaderText;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    var cellValue = dataGridView1.Rows[i].Cells[j].Value;
                    xlWorksheet.Cells[i + 2, j + 1] = cellValue?.ToString() ?? string.Empty;
                }
            }

            Microsoft.Office.Interop.Excel.Range range = xlWorksheet.UsedRange;
            range.AutoFormat(Microsoft.Office.Interop.Excel.XlRangeAutoFormat.xlRangeAutoFormatTable1);

            xlApp.Visible = true;
        }
    }
}
