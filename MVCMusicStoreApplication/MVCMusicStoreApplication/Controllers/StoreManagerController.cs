using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCMusicStoreApplication.Models;

namespace MVCMusicStoreApplication.Controllers
{
    public class StoreManagerController : Controller
    {
        private MVCMusicStoreApplicationDB db = new MVCMusicStoreApplicationDB();

        // GET: StoreManager
        public ActionResult Index()
        {
            try
                {
                    var albums = db.Albums.Include(a => a.Artist).Include(a => a.Genre);
                    return View(albums.ToList());
                }
                catch (Exception ex)
                {
                return View();
            }
        }
        
        public ActionResult DailyDeal()
        {
            var album = GetDailyDeal();
            return PartialView("_DailyDeal", album);
        }

        private Album GetDailyDeal()
        {
            var album = db.Albums.OrderBy(a => System.Guid.NewGuid()).First();
            album.Price *= 0.5m;    // If we want just the price  
            return album;
        }

        public ActionResult ArtistSearch(string q)
        {
            var artists = GetArtists(q);    // Needs Fixed
            return PartialView(artists);
        }

        private List<Artist> GetArtists(string searchstring)
        {
            return db.Artists.Where(a => a.Name.Contains(searchstring)).ToList();
        }
       

        // GET: StoreManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: StoreManager/Create
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name");
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            return View();
        }

        // POST: StoreManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl,InStock,CountryOfOrigin")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            return View(album);
        }

        // GET: StoreManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            return View(album);
        }

        // POST: StoreManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl,InStock,CountryOfOrigin")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            return View(album);
        }

        // GET: StoreManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Linq()
        {
            //1. Returns all albums

            var albums = db.Albums;
            if (albums == null)
            {
                return HttpNotFound();
            }

            // 2. Returns albums by a specific artist
            var albumsbyartist = (from a in albums
                                  where a.Artist.Name == "Chic"
                                  select a);

            // 3. Returns albums in a specific genre
            var albumsbygenre = (from a in albums
                                 where a.Genre.Name == "Classical"
                                 orderby a.Title descending
                                 select a);

            //4. Returns album by name
            var albumsbyname = (from a in albums
                                where a.Title == "Stormbringer"
                                select a);

            // 5. Returns specific album by Id - use find() to identify a record by primary key
            //var albumById = db.lbums.Find(4);

            ViewBag.AlbumsByName = new SelectList(albumsbyname, "AlbumId", "Title", albums.First().AlbumId);
            ViewBag.AlbumsByGenre = new SelectList(albumsbygenre, "AlbumId", "Title", albums.First().AlbumId);
            ViewBag.AlbumsByArtist = new SelectList(albumsbyartist, "AlbumId", "Title", albums.First().AlbumId);
            return View();
        }

        public ActionResult LinqExtension()
        {
            var AlbumsByName = db.Albums.Where(x => x.Title == "Stormbringer");
            var AlbumsByGenre = db.Albums.Where(x => x.Genre.Name == "Classical").OrderByDescending(x => x.Title);
            var AlbumsByArtist = db.Albums.Where(x => x.Artist.Name == "Chic");

            ViewBag.AlbumsByName = new SelectList(AlbumsByName, "AlbumId", "Title", AlbumsByName.First().AlbumId);
            ViewBag.AlbumsByGenre = new SelectList(AlbumsByGenre, "AlbumId", "Title", AlbumsByGenre.First().AlbumId);
            ViewBag.AlbumsByArtist = new SelectList(AlbumsByArtist, "AlbumId", "Title", AlbumsByArtist.First().AlbumId);
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", db.Artists.First().ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", db.Genres.First().GenreId);

            return View();
        }

        public ActionResult Test()
        {
            var albums = db.Albums;
            // This format is LINQ Extensions
            var albumsbyname = albums.Where(x => x.Title == "Stormbringer");
            var albumsbyartist = albums.Where(x => x.Artist.Name == "Chic");
            var albumsbygenre = albums.Where(x => x.Genre.Name == "Classical").OrderByDescending(x => x.Title);


            // This format is LINQ It can also be written in this format below 
            /*
            var albumsbyname = (from a in albums
                                where a.Title == "Stormbringer"
                                select a);

            var albumsbyartist = (from a in albums
                                 where a.Artist.Name == "Chic"
                                 select a);
            var albumsbygenre = (from a in albums
                                 where a.Genre.Name == "Classical"
                                 orderby a.Title descending
                                 select a);
            */

            ViewBag.AlbumsByName = new SelectList(albumsbyname, "AlbumId", "Title", albumsbyname.First().AlbumId);
            ViewBag.AlbumsByArtist = new SelectList(albumsbyartist, "AlbumId", "Title", albumsbyartist.First().AlbumId);
            ViewBag.AlbumsByGenre = new SelectList(albumsbygenre, "AlbumId", "Title", albumsbygenre.First().AlbumId);
            return View();
        }
    }
}
