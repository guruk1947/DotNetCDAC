using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisConnected
{
    internal class EmpDAL
    {
        string CS = ConfigurationManager.ConnectionStrings["Cstring"].ConnectionString;
        MySqlConnection conn;
        MySqlDataAdapter DA;
        DataSet DS;
        
    }
}
