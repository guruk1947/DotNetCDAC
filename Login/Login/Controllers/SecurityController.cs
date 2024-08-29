using Login.DAL;
using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    
    public class SecurityController : Controller
    {
        LoginDAL dal = new LoginDAL();
        // GET: Security
        public ActionResult Index(User u)
        {
            ViewData["status"] = TempData["status"];
            return View(u);
        }


        // GET: Security/Create
        public ActionResult login()
        {

            
            return View();


        }

        // POST: Security/Create
        [HttpPost]
        public ActionResult login(User u)
        {
            if (ModelState.IsValid)
            {

            
            try
            {
                // TODO: Add insert logic here
                int i=dal.SearchUser(u);
                if (i == 1)
                {
                    Session["user"] = i;
                    TempData["status"] = "Login Successfull...!!!";
                    return RedirectToAction("Index",u);
                }
                else
                {
                    ViewData["status"] = "Invalid Credentials...";
                    return View("login");
                }
            }
            catch
            {
                return View();
            }
            }
            return View();
        }

        public ActionResult logout()
        {
            Session["user"]=string.Empty;
            Session.Abandon();
            ViewData["status"] = "Logged out...";
            return View("login");


        }



    }
}
