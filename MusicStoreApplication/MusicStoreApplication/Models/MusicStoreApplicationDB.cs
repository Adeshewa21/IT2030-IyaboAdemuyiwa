using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusicStoreApplication.Models
{
    public class MusicStoreApplicationDB : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MusicStoreApplicationDB() : base("name=MusicStoreApplicationDB")
        {
        }

        public System.Data.Entity.DbSet<MusicStoreApplication.Models.Album> Albums { get; set; }

        public System.Data.Entity.DbSet<MusicStoreApplication.Models.Artist> Artists { get; set; }

        public System.Data.Entity.DbSet<MusicStoreApplication.Models.Genre> Genres { get; set; }
    }
}
