using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /*
             try
            {
                var events = db.Events.Include(e => e.Home);
                return View(events.ToList());
            }
            catch (Exception ex)
            {
                return View();
            }              
             */
            return View();
        }
        /*
        public ActionResult LastMinuteDeals()
        {
            var event = GetLastMinuteDeals();
            return PartialView("_LastMinuteDeals")
        }
        private Event LastMinuteDeals()
        {
            return Event;
        }

        */
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