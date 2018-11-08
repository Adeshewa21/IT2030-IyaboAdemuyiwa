using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStoreApplication.Models.ViewModels;
using MVCMusicStoreApplication.Models;

namespace MVCMusicStoreApplication.Controllers
{
    public class ShoppingCartController : Controller
    {
        MVCMusicStoreApplicationDB dbContext = new MVCMusicStoreApplicationDB();

        // GET: ShoppingCart
        public ActionResult Index()
        {
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);
            ShoppingCartViewModel vm = new ShoppingCartViewModel()
            {
                CartItems = cart.GetCartItems(), // This doesn't take any parameter
                CartTotal = cart.GetCartTotal()
            };
            return View(vm); 
        }

        
        // GET: /ShoppingCart/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // id is AlbumId
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(id);

            return RedirectToAction("Index");            
        }

        // Post: Ajax Call
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // id == RecordId
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);
            string albumTitle = dbContext.Carts.SingleOrDefault(c => c.RecordId == id).AlbumSelected.Title;
            //string albumTitle = dbContext.Carts.SingleOrDefault(c => c.RecordId == id).AlbumSelected.Title;
            int itemCnt = cart.RemoveFromCart(id);


            ShoppingCartRemoveViewModel vm = new ShoppingCartRemoveViewModel()
            {
                ItemCount = itemCnt,
                DeleteId = id,
                CartTotal = cart.GetCartTotal(),
                //CartCount = 0,
                Message = albumTitle + " has been removed from the cart"

            };

            return Json(vm);
        }
    }
}