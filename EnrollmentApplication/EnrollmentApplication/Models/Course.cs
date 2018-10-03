using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnrollmentApplication.Models
{
    public class Course
    {
        //public Course(int CourseId, string Coursetitle, string CourseDescription, string CourseCredits, bool IsActive, string AssignedCampus, string EnrollmentSemester, string EnrollmentYear)
        //{

        //}

      
        public virtual int CourseId { get; set; }

        public virtual string Coursetitle { get; set; }

        public virtual string CourseDescription { get; set; }

        public virtual string CourseCredits { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual string AssignedCampus { get; set; }

        public virtual string EnrollmentSemester { get; set; }

        public virtual int EnrollmentYear { get; set; }

    }
}