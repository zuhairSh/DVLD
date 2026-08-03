using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataDVLDLayer
{
    class clsConnection
    {
        //Enter the database connection details here.
        static public string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionDataStrings"].ConnectionString;
    }
}
