using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class AgentDAL : IAgentDAL
    {
        private string CS= ConfigurationManager.ConnectionStrings["Qstring"].ConnectionString;
        List<Agent> l= new List<Agent>();

        public int agentDelete(int id)
        {
            int i=0;
            using (MySqlConnection conn = new MySqlConnection(CS))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType=System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "agentDelete";
                    cmd.Parameters.AddWithValue("id", id);
                    i=cmd.ExecuteNonQuery();
                }
                conn.Close();

            }
            return i;
        }

        public int agentInsert(Agent agent)
        {   
            int i=0;
            using (MySqlConnection conn = new MySqlConnection(CS)) 
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType= System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "insertAgent";
                    cmd.Parameters.AddWithValue ("name", agent.Name);
                    cmd.Parameters.AddWithValue("ph", agent.mob);
                    try
                    {
                        i = cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                }
                conn.Close();
            }
            return i;
        }

        public int agentUpdate(Agent agent)
        {
            int i = 0;
            using (MySqlConnection conn = new MySqlConnection(CS))
            {
                conn.Open();
                using(MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "agentUpdate";
                    cmd.Parameters.AddWithValue("id", agent.id);
                    cmd.Parameters.AddWithValue("name", agent.Name);
                    cmd.Parameters.AddWithValue("ph", agent.mob);
                    i =cmd.ExecuteNonQuery(); 
                }
                conn.Close(); return i;
            }
        }

        public Agent GetAgentDetails(int id)
        {
            Agent agent;
            using (MySqlConnection conn = new MySqlConnection(CS))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {

                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "agentDetails";
                    cmd.Parameters.AddWithValue("x", id);
                    MySqlDataReader DR = cmd.ExecuteReader();
                   
                    DR.Read();
                        agent = new Agent()
                        {
                            id = Convert.ToInt32(DR[0].ToString()),
                            Name = DR[1].ToString(),
                            mob = Convert.ToInt64(DR[2].ToString())
                        };
                        

                    
                    conn.Close();
                }

            }
            return agent;
        }

        public List<Agent> GetAllAgents()
        {
            using (MySqlConnection conn = new MySqlConnection(CS))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {

                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "display_agent";
                    
                    MySqlDataReader DR = cmd.ExecuteReader(System.Data.CommandBehavior.SequentialAccess);
                    while (DR.Read())
                    {
                        Agent agent = new Agent()
                        {
                            id = Convert.ToInt32(DR[0].ToString()),
                            Name = DR[1].ToString(),
                            mob = Convert.ToInt64(DR[2].ToString())
                        };
                        l.Add(agent);

                    }
                    conn.Close();
                }

            }
            return l;

        }
    }
}