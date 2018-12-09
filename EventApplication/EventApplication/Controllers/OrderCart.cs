using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventApplication.Controllers
{
    public class OrderCart
    {
        public string OrderCartId;
        private const string OrderSessionKey = "OrderId";

        EventContextDB db = new EventContextDB();

        // The HttpContext object is unique to every session 
        // As long as browser is not close to start a new session user will have access to their order and or cart
        public static OrderCart GetOrder(HttpContextBase context)   // OrderCartId is one of the properties
        {
            OrderCart order = new OrderCart();
            order.OrderCartId = order.GetOrderId(context);
            return order;
        }

        public string GetOrderId(HttpContextBase context)
        {
            string orderId;
            if (context.Session[OrderSessionKey]==null)
            {
                // Create order id and add it to the session variable if it does not exist
                orderId = Guid.NewGuid().ToString();
                context.Session[OrderSessionKey] = orderId; // That's how to create a session variable
            }
            else
            {
                // Retrieve order id
                orderId = context.Session[OrderSessionKey].ToString();
            }
            return orderId;
        }

        public List<Order> GetOrderItems()
        {
            return db.Orders.Where(order => order.OrderId == OrderCartId).ToList();
        }

        public decimal GetOrderTotal()
        {
            /*
            On the video illustration we have this below
            decimal? total = (from cartItems in db.Carts)
                where cartItems.CartId == ShoppingCartId
                select cartItems.AlbumSelected.Price * (int?) cart.Items.Count.Sum();
            return total ?? decimal.Zero
            */
            return decimal.Zero;    //This will always return zero unless I write code
        }
    }
}