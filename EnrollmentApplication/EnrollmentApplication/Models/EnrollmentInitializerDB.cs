using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EnrollmentApplication.Models
{
    public class EnrollmentInitializerDB : DropCreateDatabaseIfModelChanges<EnrollmentDB>

    {
        protected override void Seed(EnrollmentDB context)
            {
            var course = new List<Course>
            {
               // new Course { Name = "IT2030" },
            };

            var student = new List<Student>
            {
              //  new Student { Name = "Esther Ademuyiwa" },
            };

            new List<Enrollment>
            {
               // new Enrollment { Grade = "99.00", Student = students.Single(s => s.LastName == "Ademuyiwa"), Course = courses.Single(c => c.Coursetitle == "Logic Programming"), Price = 8.99M, Artist = artists.Single(a => a.Name == "Aaron Copland & London Symphony Orchestra"), AlbumArtUrl = "/Content/Images/placeholder.gif" },
            }.ForEach(e => context.Enrollments.Add(e));
            
        
        }
            
    }
}
