using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    internal interface IAgentDAL
    {
        List<Agent> GetAllAgents();
        Agent GetAgentDetails(int id);
        int agentUpdate(Agent agent);
        int agentDelete(int id);
        int agentInsert(Agent agent);
    }
}
