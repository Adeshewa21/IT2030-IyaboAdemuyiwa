using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab03.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public string Index()
        {
            return "Product/Index is displayed";
        }

        // GET: Product/Browse
        public string Browse()
        {
            return "Browse displayed";
        }

        // GET: Product/Details/105 => Routing
        public string Details(int id)
        {
            return "Details displayed for ID=" + id;
        }

        // GET: Product/Location (by genre) => Query string
        public string Location(string genre)
        {
            return HttpUtility.HtmlEncode("Location displayed for zip=" + genre);
        }
    }
}
