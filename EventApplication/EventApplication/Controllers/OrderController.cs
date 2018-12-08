using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventApplication.Models.ViewModels;
using EventApplication.Models;

namespace EventApplication.Controllers
{
    public class OrderController : Controller
    {
        EventContextDB dbContext = new EventContextDB();

        // GET: Order
        public ActionResult Index()
        {
            OrderCart order = OrderCart.GetOrder(this.HttpContext);
            //OrderCartViewModel vm = new OrderCartViewModel()
            //{
            //    OrderItems = order.GetOrderItems();     // This doesn'd take any parameter
            //    OrderTotal = GetOrderTotal()
           // }
            return View();
        }

        //GET: /Order/AddOrder/5
        public ActionResult AddOrder()
        {
            return View();
        }

        [HttpPost] // To avoid people making deletion to codes
        //Post: Ajax call
        public ActionResult RemoveOrder()
        {
            return View();
        }
        
        //Post: /Order/Register/5
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Summary()
        {
            return View();
        }        
    }
}