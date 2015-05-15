using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace HarvestBandFestival.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {

            ViewBag.ClaimsIdentity = Thread.CurrentPrincipal.Identity;
            // TODO make this reflect User's contact info
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}