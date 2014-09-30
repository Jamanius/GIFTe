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
        private readonly Lazy<LightSpeedContext<LightSpeedModelUnitOfWork>> _lazyContext = new Lazy<LightSpeedContext<LightSpeedModelUnitOfWork>>(
           LightSpeedHelper.GetLightSpeedContext);



        public LightSpeedContext<LightSpeedModelUnitOfWork> Context
        {
            get { return _lazyContext.Value; }
        }
        public ActionResult Index()
        {
            using (var unitOfWork = Context.CreateUnitOfWork())
            {

            }
            return View();

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