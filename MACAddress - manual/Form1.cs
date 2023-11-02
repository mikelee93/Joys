using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MACAddress
{
    public partial class Form1 : Form
    {
        private string csvFilePath;
        private string lastMAC;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //private readonly string connectionString = @"Data Source=;Database=;User Id=;Password=;MultipleActiveResultSets=True;";
        private readonly string connectionString = @"Data Source=;Database=;User Id=;Password=;MultipleActiveResultSets=True;";

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "CSV Files|*.csv",
                Title = "Select a CSV File",
                //InitialDirectory = @"C:\Users\Joy\Desktop"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                csvFilePath = ofd.FileName;

                var lines = File.ReadLines(csvFilePath).ToList();
                if (lines.Count < 2)
                {
                    MessageBox.Show("No datas in csv.");
                    return;
                }

                var headers = lines[0].Split(',');
                int columnIndex = Array.FindIndex(headers, header => header.Trim().Equals("MAC_Address"));

                if (columnIndex == -1)
                {
                    MessageBox.Show("Can't find the header.");
                    return;
                }

                lastMAC = lines[1].Split(',')[57].Trim();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSerial.Text) && !string.IsNullOrWhiteSpace(txtMAC.Text))
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var updateCommand = new SqlCommand($"UPDATE products SET macAddress = '{txtMAC.Text}' WHERE snum = '{txtSerial.Text}'", connection);
                    updateCommand.ExecuteNonQuery();

                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Serial Number or MAC Address is missing.");
            }

            RefreshDataGridView();
        }
        private FileInfo GetLatestFile(string directory, string filePattern)
        {
            var directoryInfo = new DirectoryInfo(directory);
            return directoryInfo.GetFiles(filePattern)
                                .OrderByDescending(f => f.LastWriteTime)
                                .FirstOrDefault();
        }

        private void txtSerial_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSerial.Text))
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var command = new SqlCommand($"SELECT macAddress FROM products WHERE snum = '{txtSerial.Text}'", connection);
                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        txtMAC.Text = reader["macAddress"].ToString();
                    }
                    else
                    {
                        txtMAC.Text = string.Empty;
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            else
            {
                txtMAC.Text = string.Empty;
            }

            RefreshDataGridView();
        }
        private void RefreshDataGridView()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand($"SELECT snum, macAddress FROM products WHERE snum LIKE '{txtSerial.Text}%'", connection);
                var adapter = new SqlDataAdapter(command);
                var table = new DataTable();

                adapter.Fill(table);

                MACAddress.DataSource = table;

                connection.Close();
            }
        }

        private void txtMAC_TextChanged(object sender, EventArgs e)
        {

        }

        private void MACAddress_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
