using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventApplication.Models;

namespace EventApplication.Controllers
{
    public class HomeController : Controller
    {
        private EventContextDB db = new EventContextDB();

        public ActionResult Index()
        {
         
            return View();
        }
        
        public ActionResult LastMinuteDeals()
        {
            try
            {
                DateTime lastMinuteDealsDate = DateTime.Now.AddDays(2);

                var events = db.Events.Include(e => e.EventType)
                    .Where(e => e.StartDate <= lastMinuteDealsDate);

                return PartialView("_LastMinuteDeals", events.ToList());

            }
            catch (Exception ex)
            {
                return View();
            };
        }
        
        public ActionResult FindanEvent(string q, string z)
        {
            var events = GetFindanEvent(q);
            return PartialView(events);
        }

        private List<Event> GetFindanEvent(string searchstring)
        {
            return db.Events
                //.Where(e => e.EventType.Type.Contains(searchstring))
                //.Where(e => e.StartDate.Contains(searchstring))
                /*
                 * AFTER ASKING PROFESSOR ON WHY ITS NOT WORKING RIGHT... THE TWO LINES BELOW ARE HER SUGGESTIONS
                Where(e => e.Title.Contains(searchstring) ||
                e.City.contains(searchstring))
                */
                .Where(e => e.Title.Contains(searchstring))
                .Where(e => e.City.Contains(searchstring))
                .Where(e => e.State.Contains(searchstring)).ToList();
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

