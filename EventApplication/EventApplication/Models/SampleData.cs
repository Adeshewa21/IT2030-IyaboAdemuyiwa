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
            var eventtypes = new List<EventType>
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
            /*
            var events = new List<Event>
            {
                new Event { Title = "School Presentation" },
                new Event { Title = "Church Conference" },
                new Event { Title = "Seniors Graduation" },
                new Event { Title = "Religion Christmas Carol" },
                new Event { Title = "Skills America's Got Talent" },
                new Event { Title = "High School Camp" },
                new Event { Title = "Word Church Womens Conference" },
                new Event { Title = "All ages Modeling Calling" },
                new Event { Title = "School Summer jam" },
                new Event { Title = "Millenials Hip Hop Music Chorus" },
            }
            */
            //}.ForEach(e => context.EventType.Add(e));
        }
    }
}