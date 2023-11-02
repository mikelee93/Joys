using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQor_Systems
{
    internal class ConnectionDB
    {
        string con = @"Data Source=192.168.1.2;Database=testJoy;User Id=sa;Password=lease-return;MultipleActiveResultSets=True;";
        //string con = @"Data Source=192.168.1.2;Database=JoyData;User Id=sa;Password=lease-return;MultipleActiveResultSets=True;";
        public string ConnectionString
        {
            get { return con; }
        }
    }
}
