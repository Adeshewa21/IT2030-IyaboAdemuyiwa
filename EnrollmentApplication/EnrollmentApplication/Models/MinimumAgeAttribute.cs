using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class MinimumAgeAttribute: ValidationAttribute
    {
        readonly int min_age;


        //Age does not meet criteria

        public MinimumAgeAttribute(int minAge): base("{0} is not correct!")
        {
            min_age = minAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                // if age < minimum age then error
                if ((int)value < min_age)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }


            return ValidationResult.Success;
        }
    }
}