using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStoreApplication.Models.ViewModels  // .ViewModels was added because it was being refenced ing Shopping CartController as ViewModels and was name different in order to avoid errors it was being addedas .ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems; // You have to step through when using this because it's multiple list
        public decimal CartTotal;  // You don't have to step through this becuase there will be only one cart
    }
}