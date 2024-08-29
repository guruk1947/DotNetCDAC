using ConnectedArch.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectedArch.DAL
{
    internal class EmployeeDAL
    {
        private static string Con_String = ConfigurationManager  .ConnectionStrings["group059_String"].ConnectionString;

        public static List<Employee> getAllEmp()
        {
            List<Employee> emp = new List<Employee>();
            using (MySqlConnection CN = new MySqlConnection(Con_String))
            {
                CN.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = CN;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "selectPro1";
                    MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                    while (dr.Read())
                    {
                        Employee employee = new Employee()
                        {
                            id = Convert.ToInt32(dr["id"]),
                            name = dr[1].ToString(),
                            designation = dr[2].ToString(),
                            salary = Convert.ToInt32(dr[3]),
                            city = dr["city"].ToString(),
                        };
                        emp.Add(employee);
                    }
                    dr.Close();

                }
                CN.Close();
            }
            return emp;
        }

        public static int insertEmp(Employee emp)
        {
            int result = -1;
            using (MySqlConnection CN = new MySqlConnection(Con_String))
            {
                using (MySqlCommand Cmd = new MySqlCommand())
                {
                    Cmd.Connection = CN;
                    Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    Cmd.CommandText = "inData";
                    Cmd.Parameters.AddWithValue("nm", emp.name);
                    Cmd.Parameters.AddWithValue("ds", emp.designation);
                    Cmd.Parameters.AddWithValue("sal", emp.salary);
                    Cmd.Parameters.AddWithValue("ct", emp.city);
                    result = Cmd.ExecuteNonQuery();
                }
                CN.Close();
            }
            return result;
        }

    }
}
