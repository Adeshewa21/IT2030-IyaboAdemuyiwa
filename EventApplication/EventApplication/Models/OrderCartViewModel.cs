using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventApplication.Models.ViewModels // View model was added because iw was being reference to OrderController as ViewModels and was name different in order to avoid errors it was being added as .ViewModels
{
    public class OrderCartViewModel
    {
        // It is going to be used/called by the Index.cshtml i.e Index View
        public List<Order> OrderItems;
        public decimal FREE;
    }
}