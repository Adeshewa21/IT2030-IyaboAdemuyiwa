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

        // Last Minute Deals

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
        //Find an Event

        public ActionResult FindanEvent(string q, string z)
        {
            var events = GetFindanEvent(q, z);
            return PartialView(events);
        }

        private List<Event> GetFindanEvent(string q, string z)
        {
            return db.Events
                .Where(e => e.Title.Contains(q) ||
                e.City.Contains(z)).ToList();
            //Use the q and z and name it different alphabet to complete the State and Location
        }

        // EventTitle Link
        [HttpGet]
        public ActionResult Browse()
        {
            var list = db.Events.ToList();
            return View(list);
        }

        // Event Details
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // Find an Event

        public ActionResult EventSearch(string q, string z)
        {
            var events = GetEventSearch(q);
            return PartialView(events);
        }

        private List<Event> GetEventSearch(string searchstring)
        {
            return db.Events
                .Where(e => e.Title.Contains(searchstring) ||
                e.City.Contains(searchstring)).ToList();
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

