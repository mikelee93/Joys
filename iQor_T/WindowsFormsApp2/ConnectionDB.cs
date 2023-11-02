using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class ConnectionDB
    {
        string con = @"Data Source=192.168.1.2;Database=testJoy;User Id=sa;Password=lease-return;";
        //string con = @"Data Source=192.168.1.2;Database=JoyData;User Id=sa;Password=lease-return;";
        public string ConnectionString
        {
            get {return con;}
        }
    }
}