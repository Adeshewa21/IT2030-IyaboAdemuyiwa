using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventApplication.Models.ViewModels;
using EventApplication.Models;
using System.Data.Entity;
using System.Net;

namespace EventApplication.Controllers
{
    public class OrderController : Controller
    {
        EventContextDB db = new EventContextDB();

        // GET: Order
        public ActionResult Index()
        {
            OrderCart order = OrderCart.GetOrder(this.HttpContext);
            OrderCartViewModel vm = new OrderCartViewModel();
            //{
            //    OrderItems = order.GetOrderItems();     // This doesn'd take any parameter
            //    OrderTotal = GetOrderTotal()
            // }
            return View();
        }

        //GET: /Order/AddOrder/5


        [HttpGet]
        public ActionResult Register(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(int? eventId, string numberOfTickets)
        {
            if (ModelState.IsValid)
            {
                Order newOrder = new Order();
                newOrder.EventId = eventId.Value;  // Passed into this method
                newOrder.NumberofTickets = numberOfTickets;  // Passed into this method

                //OrderCartViewModel orderCart = new OrderCartViewModel();
                //orderCart.OrderItems = new List<Order>();
                
                //orderCart.OrderItems.Add(newOrder);

                db.Orders.Add(newOrder);
                db.SaveChanges();
            }

            

            //ViewBag.OrderId = new SelectList("NumberofTickets", @orderCartViewModel.OrderItems);
            //return View(@orderCartViewModel);
            //db.SaveChanges();
            //db.SaveChanges();
            return RedirectToAction("OrderSummary");
        }





        [HttpPost] // To avoid people making deletion to codes
        //Post: Ajax call
        public ActionResult RemoveOrder()
        {
            return View();
        }

        /*
        //Post: /Order/Register/5
        public ActionResult Register()
        {
            Order orderItem = dbContext.Orders.SingleOrDefault(o => o.OrderId == OrderId && o.EventId == id);
            if (orderItem == null)
            {

            }
            return View();
        }
        */
        public ActionResult Summary()
        {
            return View();
        }
    }
}