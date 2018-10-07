using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class Course
    {
        public virtual int CourseId { get; set; }

        [Display(Name = "Course Title")]
        [Required(ErrorMessage = "Course Title cannot be blank")]
        [StringLength(150)]
        public virtual string Coursetitle { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Course Description cannot be blank")]
        [StringLength(int.MaxValue)]
        public virtual string CourseDescription { get; set; }

        [Display(Name = "Number of Credits")]
        [Required(ErrorMessage = "Number of Credits cannot be blank")]
        [Range(1,4,ErrorMessage = "Course Credits must be between 1 and 4")]
        public virtual string CourseCredits { get; set; }
        /*public virtual bool IsActive { get; set; }
        public virtual string AssignedCampus { get; set; }
        public virtual string EnrollmentSemester { get; set; }
        public virtual int EnrollmentYear { get; set; }
        */
    }
}
