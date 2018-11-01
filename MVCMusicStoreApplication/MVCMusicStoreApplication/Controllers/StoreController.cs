using MVCMusicStoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStoreApplication.Controllers
{
    public class StoreController : Controller
    {
        MVCMusicStoreApplicationDB db = new MVCMusicStoreApplicationDB();

        // GET: Store
        [HttpGet]
        public ActionResult Index(int id)
        {
            var list = db.Albums.ToList();

            return View(list);
        }

        // GET: Store
        [HttpGet]
        public ActionResult Browse()
        {
            var list = db.Genres.ToList();

            return View(list);            
        }

        // GET: Store
        [HttpGet]
        public ActionResult Details(int id)
        {
            var list = db.Albums.ToList();
            return View();
        }
    }
}