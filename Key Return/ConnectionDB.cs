using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Key_Return
{
    internal class ConnectionDB
    {
       string con = @"Data Source=192.168.1.21\MDOS;Database=SmartClient_Test;User Id=MSC;Password=j0ysystems!;MultipleActiveResultSets=True;";
       // string con = @"Data Source=192.168.1.21\MDOS;Database=SmartClient;User Id=MSC;Password=j0ysystems!;MultipleActiveResultSets=True;";
        public string ConnectionString
        {
            get { return con; }
        }
    }
}
