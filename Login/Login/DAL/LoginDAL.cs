using Login.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Login.DAL
{
    public class LoginDAL
    {
        private string con= ConfigurationManager.ConnectionStrings["Cstring"].ConnectionString;
        MySqlConnection CN;
        MySqlCommand cmd;

        public int SearchUser(User u)
        {
            int i = 0;
            using(CN = new MySqlConnection(con))
            {
                CN.Open();
                using (cmd = new MySqlCommand())
                {
                    cmd.Connection = CN;
                    cmd.CommandType=System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "searchEmp";
                    cmd.Parameters.AddWithValue("uName", u.uName);
                    cmd.Parameters.AddWithValue("pass", u.pass);
                    MySqlDataReader DR = cmd.ExecuteReader();
                    if (DR.Read()) { i = 1; }
                }
                CN.Close();
                cmd = null;
                CN= null;
            }
            return i;
        }
    }
}