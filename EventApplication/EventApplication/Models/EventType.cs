using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApplication.Models
{
    public class EventType
    {

        public virtual int EventTypeId { get; set; }

        [StringLength(50, ErrorMessage = "Type cannot exceed 50 characters")]
        public virtual string Type { get; set; }

    }
}