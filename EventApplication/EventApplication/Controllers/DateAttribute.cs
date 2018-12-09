/*
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
        // Find an Event

        public ActionResult FindanEvent(string q, string z)
        {
            var events = GetFindanEvent(q);
            return PartialView(events);
        }

        private List<Event> GetFindanEvent(string searchstring)
        {
            return db.Events 
                .Where(e => e.Title.Contains(searchstring) ||
                e.City.Contains(searchstring)).ToList();               
        }

        // EventTitle Link
        [HttpGet]
        public ActionResult EventTitle()
        {
            var list = db.Events.ToList();
            return View(list);
        }
        /*
        // EventIndex
        [HttpGet]
        public ActionResult EventIndex(int id)
        {
            var list = db.Events.ToList();
            return View(list);
        }

        // Event Details
        [HttpGet]
        public ActionResult EventDetails(int? id)
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
        *
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


*/























using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventApplication.Controllers
{
    public class DateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToDateTime(value) > DateTime.Today)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Date cannot be in the past");
            }
        }
    }
}