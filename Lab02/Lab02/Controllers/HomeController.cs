using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab02.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About method is being called.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact method is being called.";

            return View();
        }

        public string Display()
        {
            return "Display method is being called";
        }
    }
}