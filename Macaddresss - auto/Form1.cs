using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Macaddresss
{
    public partial class Form1 : Form
    {
        //private readonly string connectionString = @"Data Source=192.168.1.2;Database=testJoy;User Id=sa;Password=lease-return;MultipleActiveResultSets=True;";
        private readonly string connectionString = @"Data Source=192.168.1.2;Database=JoyData;User Id=sa;Password=lease-return;MultipleActiveResultSets=True;";

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string directoryPath = @"C:\specCollect\Laptop\MACAddress";
            var csvFiles = Directory.GetFiles(directoryPath, "*.csv");

            foreach (var csvFile in csvFiles)
            {
                ProcessCsvFile(csvFile);
            }

            Application.Exit();
        }

        private void ProcessCsvFile(string csvFilePath)
        {
            var lines = File.ReadLines(csvFilePath).ToList();
            if (lines.Count < 2)
            {
                return;
            }

            var headers = lines[0].Split(',');
            int columnIndex = Array.FindIndex(headers, header => header.Trim().Equals("MAC_Address"));

            if (columnIndex == -1)
            {
                return;
            }

            string lastMAC = lines[1].Split(',')[57].Trim();
            string serialNumber = Path.GetFileNameWithoutExtension(csvFilePath).Split('_')[0];
            string formattedMAC = lastMAC.Replace("-", "");

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand($"SELECT * FROM products WHERE snum = '{serialNumber}'", connection);
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Close();

                    var updateCommand = new SqlCommand($"UPDATE products SET macAddress = '{formattedMAC}' WHERE snum = '{serialNumber}'", connection);
                    updateCommand.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
            private FileInfo GetLatestFile(string directory, string filePattern)
            {
                var directoryInfo = new DirectoryInfo(directory);
                return directoryInfo.GetFiles(filePattern)
                                    .OrderByDescending(f => f.LastWriteTime)
                                    .FirstOrDefault();
            }
        }
    }

