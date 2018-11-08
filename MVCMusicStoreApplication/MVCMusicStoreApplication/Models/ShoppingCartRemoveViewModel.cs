using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStoreApplication.Models.ViewModels
{
    // This is what the controller will return to the view to show to th user
    public class ShoppingCartRemoveViewModel
    {
        public int DeleteId; // Match up with RecordId
        public decimal CartTotal;
        public int ItemCount;
        public int CartCount;
        public string Message;
    }
}