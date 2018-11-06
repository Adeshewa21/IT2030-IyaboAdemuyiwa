﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCMusicStoreApplication.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }   // It will Auto Generated by EF Using the Key will override the CartId to RecordId also add the SystemComponentModel.DataAnnotations
        public string CartId { get; set; }  // Not Unique. Will be common but multiple that belong to one user
        public int AlbumId { get; set; }
        public int Count { get; set; }
        public virtual Album AlbumSelected { get; set; }
        public DateTime DateCreated { get; set; }        
    }
}