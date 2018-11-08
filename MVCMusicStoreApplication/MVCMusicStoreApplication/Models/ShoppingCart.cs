using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStoreApplication.Models
{
    public class ShoppingCart
    {
        public string ShoppingCartId;
        private const string CartSessionKey = "CartId";

        MVCMusicStoreApplicationDB db = new MVCMusicStoreApplicationDB();

        public static ShoppingCart GetCart(HttpContextBase context) // ShoppingCartId is one of the properties object
        {
            ShoppingCart cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        public string GetCartId(HttpContextBase context)
        {
            string cartId;
            if (context.Session[CartSessionKey]==null)
            {                
                // Create a cart id and add it to the session variable if it does not exist
                cartId = Guid.NewGuid().ToString();
                context.Session[CartSessionKey] = cartId; // That's how to create a session variable
            }
            else
            {
                // Retrieve cart id 
                cartId = context.Session[CartSessionKey].ToString();
            }
            return cartId;
        }

        public List<Cart> GetCartItems()
        {
            return db.Carts.Where(cart => cart.CartId == ShoppingCartId).ToList();
        }

        public decimal GetCartTotal()
        {
            decimal? total = (from cartItems in db.Carts
                where cartItems.CartId == ShoppingCartId    // This will return all the cartItems that matches the CartId  
                select cartItems.AlbumSelected.Price * (int?) cartItems.Count).Sum(); // and will not return the entire object but will return this specific Price Will sum and go to total
            return total ?? decimal.Zero;   // This will always return Zero unless code is written
        }

        public void AddToCart(int id)
        {            
            Cart cartItem = db.Carts.SingleOrDefault(c => c.CartId == ShoppingCartId && c.AlbumId == id);

            // CartItem does not exist in the db => add CartItem to database 
            if (cartItem == null)
            {
                Album album = db.Albums.SingleOrDefault(a => a.AlbumId == id);
                cartItem = new Cart() {
                    CartId = ShoppingCartId,
                    AlbumId= id,
                    AlbumSelected = album,
                    Count=1,
                    DateCreated = DateTime.Now
                };

                db.Carts.Add(cartItem);
            }
            else
            {
                // CartItem exists already in db => Update count
                cartItem.Count++;    
            }
            db.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            Cart cartItem = db.Carts.SingleOrDefault(cart => cart.RecordId == id);
            int count = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    count = cartItem.Count;
                }
                else
                {
                    db.Carts.Remove(cartItem);
                    count = 0;
                }

                db.SaveChanges();
            }
            
            return count;
        }
    }
}