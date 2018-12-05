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

        public virtual string Type { get; set; }

    }
}

