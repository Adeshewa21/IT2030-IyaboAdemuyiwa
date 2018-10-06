using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStoreApplication.Models
{
    public class Album
    {
        public virtual int AlbumId { get; set; }
        public virtual int GenreId { get; set; }
        public virtual int ArtistId { get; set; }
        public virtual string Title { get; set; }
        public virtual decimal Price { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual string AlbumArtUrl { get; set; }
        public virtual string AdditionalInfo { get; set; }
        public virtual string CountryOfOrigin { get; set; }         // This will be a RadioButton
        public virtual bool InStock { get; set; }                   // This will be a CheckBox
        // Those two fields in Line 19-20 will be added to index fields in order to see those values
    }
}
