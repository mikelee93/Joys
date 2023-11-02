using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQor_inbound_T
{
    internal class ConnectionDB
    {
        string con = @"Data Source=; Database=testserver; User Id=" "; Password=" "; MultipleActiveResultSets=True;";
        //string con = @"Data Source=; Database=mainserver; User Id=" "; Password=" "; MultipleActiveResultSets=True;";
        public string ConnectionString
        {
            get { return con; }
        }
    }
}
