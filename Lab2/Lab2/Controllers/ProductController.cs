using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public string Index()
        {
            return "Product Index";
        }

        // GET: Product/Browse
        public string Broswe()
        {
            return "Product Browse";
        }

        // GET: Product/Details/105
        public string Details()
        {
            return "105";
        }

        // GET: Product/Locations(by genre)
        public string Location()
        {
            return "zip=44124";
        }
    }
}

