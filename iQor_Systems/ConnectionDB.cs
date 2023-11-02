using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQor_Systems
{
    internal class ConnectionDB
    {
        string con = @"Data Source=;Database=;User Id=;Password=;MultipleActiveResultSets=True;";
        //string con = @"Data Source=;Database=;User Id=;Password=;MultipleActiveResultSets=True;";
        public string ConnectionString
        {
            get { return con; }
        }
    }
}
