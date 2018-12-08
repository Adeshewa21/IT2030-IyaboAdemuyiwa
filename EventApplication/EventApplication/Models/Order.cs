using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventApplication.Models
{
    public class Order
    {
        [Key]
        public int RecordId { get; set; }
        public string OrderId { get; set; } // Not Unique
        public int EventId { get; set; }
        public int Count { get; set; }

        /* Navigation property always has to be virtual because entity framework is set set for mvc by default it does lazy loadings
         whic means it will not load this Event Object into Memory until Someone Ask For It*/
        public virtual Event EventSelected { get; set; } // It is going to link Order into Event

        public DateTime StartDate { get; set; }
        public virtual string NumberofTickets { get; set; }
    }
}