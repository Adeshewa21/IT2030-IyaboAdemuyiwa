using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class Student : IValidatableObject
    {
        public virtual int StudentId { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name cannot be blank")]
        [StringLength(50)]
        public virtual string LastName { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name cannot be blank")]
        [StringLength(50)]
        public virtual string FirstName { get; set; }

        [MinimumAge(20,ErrorMessage ="Age does not meet minimum requirement!!!")] // Custom Data Annotation
        public int Age { get; set; }

        public virtual string Address1 { get; set; }
        
        public virtual string Address2 { get; set; }

        public virtual string City { get; set; }

        public virtual string Zipcode { get; set; }

        public virtual string State { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            int maxZipcode = 5;
            int maxState = 2;

            //Address1
            //validation 1 Check if address 2 is the same as address 1 if so show an error "Address 2 cannot be the same as Address 1" on Address 2 Field
            if ((Address1 != Address2))
            {
                //error
                yield return (new ValidationResult("Address 2 cannot be the same as Address 1", new[] { "Address1" }));
            }          

            if (int.Parse(Zipcode) > maxZipcode)
            {
                //error 
                yield return (new ValidationResult("Enter a 5 digit Zipcode", new[] { "Zipcode" }));
            }
            
            if (State.Split(' ').Length > maxState)
            {
                //error 
                yield return (new ValidationResult("Enter a 2 digit State", new[] { "State" }));
            }
        }
    }
}

