using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connected
{
     class AgentDAL
    {
        MySqlConnection con;
        MySqlCommand cmd;
        int currentindex = 0;
        List<Agent> agents = new List<Agent>();
        string conn = ConfigurationManager.ConnectionStrings[ "Cstring"].ConnectionString ;

        public List<Agent> getAllAgents()
        {
            using (con = new MySqlConnection(conn))
            {
                con.Open();
                using (cmd = con.CreateCommand())
                {
                    cmd.Connection = con;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "display_agent";
                    MySqlDataReader DR = cmd.ExecuteReader();
                    while (DR.Read())
                    {
                        Agent agent = new Agent()
                        {
                            ID = Convert.ToInt32((DR[0]).ToString()),
                            Name = (DR[1]).ToString(),
                            Mobile = Convert.ToInt64(DR[2].ToString())
                        };
                        agents.Add(agent);
                    }
                    con.Close();

                }

            }
            return agents;
        }

        public void saveAgent(Agent agent)
        {
            using (con = new MySqlConnection(conn))
            {
                con.Open();
                using (cmd = con.CreateCommand())
                {
                    cmd.Connection = con;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertAgent";
                    cmd.Parameters.AddWithValue("name", agent.Name);
                    cmd.Parameters.AddWithValue("ph", agent.Mobile);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }

            }
        }

        public void updateAgent(Agent agent)
        {
            using (con = new MySqlConnection(conn))
            {
                con.Open();
                using (cmd = con.CreateCommand())
                {
                    cmd.Connection = con;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "agentUpdate";
                    cmd.Parameters.AddWithValue("id", agent.ID);
                    cmd.Parameters.AddWithValue("name", agent.Name);
                    cmd.Parameters.AddWithValue("ph", agent.Mobile);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }

            }
        }

        public void deleteAgent(int ID)
        {
            using (con = new MySqlConnection(conn))
            {
                con.Open();
                using (cmd = con.CreateCommand())
                {
                    cmd.Connection = con;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "agentDelete";
                    cmd.Parameters.AddWithValue("id", ID);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }

            }
        }
    }
}
