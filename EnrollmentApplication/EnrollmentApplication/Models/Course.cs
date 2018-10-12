using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class Course : IValidatableObject
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

        public virtual string InstructorName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            int maxCourseCredits = 4;
            int maxWords = 5;

            //validation 1 - Credits has to be 1-4

            if (int.Parse(CourseCredits) > maxCourseCredits)
            {
                //error 
                yield return (new ValidationResult("Course Credits must be between 1 and 4",new[] {"Credits" }));
            }

            //validation 2 - Description cannot exceed 5 words

            if (CourseDescription.Split(' ').Length > maxWords)
            {
                //error 
                yield return (new ValidationResult("Course Descritpion is too wordy!", new[] { "Description" }));
            }

            

            
        }
    }
}
