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
        public ActionResult RemoveFromCart()
        {
            return View();
        }
    }
}