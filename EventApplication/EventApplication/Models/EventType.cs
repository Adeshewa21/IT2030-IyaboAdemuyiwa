﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EventApplication.Models
{
    [Authorize]
    public class EventType
    {
        public virtual int EventTypeId { get; set; }
        //public virtual int EventId { get; set; }
        //public virtual int OrderId { get; set; }

        [Display(Name = "Title")]
        [Required]
        [StringLength(50)]
        public virtual string Title { get; set; }

        [Display(Name = "Event Description")]
        [StringLength(150)]
        public virtual string EventDescription { get; set; }

        [Display(Name = "Start Date")]
        [Required]       
        public virtual DateTime StartDate { get; set; }

        [Display(Name = "Start Time")]
        [Required]
        public virtual TimeSpan StartTime { get; set; }

        [Display(Name = "End Date")]
        [Required]
        public virtual DateTime EndDate { get; set; }

        [Display(Name = "End Time")]
        [Required]
        public virtual TimeSpan EndTime { get; set; }

        [Required]
        public virtual string Location { get; set; }

        public virtual string Type { get; set; }

        [Display(Name = "Organizer Name")]
        [Required]
        public virtual string OrganizerName { get; set; }

        [Display(Name = "Organizer Contact Info")]
        public virtual string OrganizerContactInfo { get; set; }

        [MinLength(1, ErrorMessage ="Maximum Tickets cannot be 0")]
        [Display(Name = "Max Tickets")]
        [Required]
        public virtual string MaxTickets { get; set; }

        [MinLength(1, ErrorMessage = "Available Tickets cannot be 0")]
        [Display(Name = "Available Tickets")]
        [Required]
        public virtual string AvailableTickets { get; set; }
    }
}