using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AgentController : Controller
    {
        IAgentDAL agentDAL;

        public AgentController(AgentDAL agentDAL)
        {
            this.agentDAL = agentDAL;
        }

        // GET: Agent
        public ActionResult Index()
        {
            ViewData["subTitle"] = "Agent List";
            ViewData["status"]=TempData["status"];
            var agents= agentDAL.GetAllAgents();
            return View(agents);
        }

        // GET: Agent/Details/5
        public ActionResult Details(int id)
        {
            var agents= agentDAL.GetAgentDetails(id);
            return View(agents);
        }

        // GET: Agent/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Agent/Create
        [HttpPost]
        public ActionResult Create(Agent agent)
        {
            try
            {
                // TODO: Add insert logic here
                int i = agentDAL.agentInsert(agent);
                if(i == 1)
                {
                   TempData["status"] = "Data inserted Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["status"] = "Data Not Inserted";
                    return RedirectToAction("Index");
                }
                
            }
            catch
            {
                TempData["status"] = "Data Not Inserted";
                return RedirectToAction("Index");
            }
        }

        // GET: Agent/Edit/5
        public ActionResult Edit(int id)
        {
            var agents = agentDAL.GetAgentDetails(id);
            return View(agents);
        }

        // POST: Agent/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Agent agent)
        {
            try
            {
                // TODO: Add update logic here
                int i = agentDAL.agentUpdate(agent);
                if (i == 1)
                {
                    TempData["status"] = "Data Updated Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["status"] = "Data Not Updated";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                TempData["status"] = "Data Not Updated";
                return RedirectToAction("Index");
            }
        }

        // GET: Agent/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                int i = agentDAL.agentDelete(id);
                if (i == 1)
                {
                    TempData["status"] = "Data Deleted Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["status"] = "Data Not Deleted";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                TempData["status"] = "Data Not Deleted";
                return RedirectToAction("Index");
            }
        }

        // POST: Agent/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            //try
            //{
            //    // TODO: Add delete logic here
            //    int i = agentDAL.agentDelete(id);
            //    if (i == 1)
            //    {
            //        TempData["status"] = "Data Deleted Successfully";
            //        return RedirectToAction("Index");
            //    }
            //    else
            //    {
            //        TempData["status"] = "Data Not Deleted";
            return RedirectToAction("Index");
            //    }
            //}
            //catch
            //{
            //    TempData["status"] = "Data Not Deleted";
            //    return RedirectToAction("Index");
            //}
        }
    }
}
