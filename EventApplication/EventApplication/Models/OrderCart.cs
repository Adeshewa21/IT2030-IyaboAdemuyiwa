using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EventApplication.Models;

namespace EventApplication.Controllers
{
    public class OrderCart
    {
        public string OrderCartId;
        private const string OrderSessionKey = "OrderId";
        private EventContextDB db = new EventContextDB();
        //EventContextDB db = new EventContextDB();
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
            if (context.Session[OrderSessionKey] == null)
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

        public List<Order> GetOrderItems() // This is going to return a list of all the OrderItems that matches the OrderCartID and the GetOrder
        {
            return db.Orders.Where(order => order.OrderId == OrderCartId).ToList();
        }
        /* on the Video it's on Video 7 close to the end of the video
         * this  load the number of tickets just like the way it is in the project instruction
        private string GetOrderTotal() // This multiplies the price of the account in the video
        {
            string total = (from orderItems in db.Orders
                            where orderItems.OrderId == OrderCartId
                            .select orderItems.NumberofTickets * (string?).Count).Sum();
            return total;           
        }
        */
    }
}