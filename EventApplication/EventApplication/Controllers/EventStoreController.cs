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
    public class EventStoreController : Controller
    {
        private EventContextDB db = new EventContextDB();

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
    }
}

