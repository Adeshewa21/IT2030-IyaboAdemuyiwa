using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class Enrollment
    {
        public virtual int EnrollmentId { get; set; }
        public virtual int CourseId { get; set; }
        public virtual int StudentId { get; set; }

        [Required]
        [RegularExpression(@"[A - F]", ErrorMessage = "Grade can only be between A - F")]
        public virtual string Grade { get; set; }
        public virtual string StudentObject { get; set; }
        public virtual string CourseObject { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
        public virtual bool IsActive { get; set; }

        [Display(Name = "Assigned Campus")]
        [Required(ErrorMessage = "Assigned Campus cannot be blank")]
        public virtual string AssignedCampus { get; set; }

        [Display(Name = "Enrollment in Semester")]
        [Required(ErrorMessage = "EnrollmentSemester cannot be blank")]
        public virtual string EnrollmentSemester { get; set; }

        [Display(Name = "Enrollment Year")]
        [Required(ErrorMessage = "Enrollment Year cannot be blank or less than 2018")]
        [Range(2018, 2019)]
        public virtual string EnrollmentYear { get; set; }

    }
}
