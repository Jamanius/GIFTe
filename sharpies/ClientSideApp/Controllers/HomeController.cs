using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientSideApp.Models;
using Mindscape;
using Mindscape.LightSpeed;
using ClientSideApp.Plumbing;

namespace ClientSideApp.Controllers
{
    public class HomeController : Controller
    {
       
        
        public ActionResult Index()
        {
            return View("Straight");

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}