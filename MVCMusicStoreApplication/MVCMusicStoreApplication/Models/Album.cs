using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVCMusicStoreApplication.Models
{
    public class Album
    {
        public virtual int AlbumId { get; set; }
        public virtual int GenreId { get; set; }
        public virtual int ArtistId { get; set; }

        [Display(Name = "Album Title")]
        [Required(ErrorMessage = "Album Title cannot be blank")]
        public virtual string Title { get; set; }

        [Display(Name = "Album Price")]
        [Required]
        [Range(0.01,100.00,ErrorMessage = "Album Price must be between $0.01 and $100.00")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public virtual decimal Price { get; set; }

        public virtual Genre Genre { get; set; }

        [Display(Name = "Album Art URL")]
        public virtual Artist Artist { get; set; }
        public virtual string AlbumArtUrl { get; set; }
        public virtual string AdditionalInfo { get; set; }
        public virtual string CountryOfOrigin { get; set; }         // This will be a RadioButton
        public virtual bool InStock { get; set; }                   // This will be a CheckBox
        // Those two fields in Line 19-20 will be added to index fields in order to see those values
    }
}
