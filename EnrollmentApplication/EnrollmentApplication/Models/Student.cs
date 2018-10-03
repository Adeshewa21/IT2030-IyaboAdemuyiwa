using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnrollmentApplication.Models
{
    public class Student
    {
        //public Student(int StudentId, string LastName, string FirstName, bool IsActive, string AssignedCampus, string EnrollmentSemester, string EnrollmentYear)
        //{

        //}
        public virtual int StudentId { get; set; }

        public virtual string LastName { get; set; }

        public virtual string FirstName { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual string AssignedCampus { get; set; }

        public virtual string EnrollmentSemester { get; set; }

        public virtual int EnrollmentYear { get; set; }

    }
}

