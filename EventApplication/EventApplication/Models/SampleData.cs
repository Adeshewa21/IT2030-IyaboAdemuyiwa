using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Data.Entity;

namespace EventApplication.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<EventContextDB>
    {
        protected override void Seed(EventContextDB context)
        {
            var eventtype = new List<EventType>
            {

                new EventType { Type = "Presentation" },
                new EventType { Type = "Conference" },
                new EventType { Type = "Graduation" },
                new EventType { Type = "Christmas Carol" },
                new EventType { Type = "America's Got Talent" },
                new EventType { Type = "Summer Camp" },
                new EventType { Type = "Ladies How Much Are You Worth" },
                new EventType { Type = "Modeling Calling" },
                new EventType { Type = "Summer Jam" },
                new EventType { Type = "Millenials Music Chorus" }
            };
    
            //}.ForEach(a => context.Albums.Add(a));

        }
        

    }

}
