using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "index";
        }

        public string Browse()
        {
            return "Browse";
        }

        public string Details(int id)
        {
            return "Details";
        }

        public string Location()
        {
            return "zip=44124";
        }
    }
}

