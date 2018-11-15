using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventApplication.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }


    public class OrganizeAnEvent
    {
        [Required(ErrorMessage = "Title should not exceed 50 characters")]
        [StringLength(50)]
        public virtual string Title { get; set; }

        [Required(ErrorMessage = "Description should not exceed 150 characters")]
        [StringLength(150)]
        public virtual string Description { get; set; }

        [Display(Name = "Event Start Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Event Start Date cannot be in the past")]
        public virtual DateTime StartDate { get; set; }

        [Display(Name = "Event End Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Event End Date cannot be less than Event Start Date")]
        public virtual DateTime EndDate { get; set; }

        [Display(Name = "Max Tickets")]
        [Required]
        public virtual string MaxTicket { get; set; }

        [Display(Name = "Available Tickets")]
        [Required]
        public virtual string AvailableTickets { get; set; }

        [Display(Name = "Organizer")]
        [Required]
        public virtual string OrganizerName { get; set; }

        [Required]
        public virtual string Time { get; set; }

        [Required]
        public virtual string Location { get; set; }

        public virtual string Type { get; set; }
        

        [Display(Name = "Organizer Contact Info")]
        public virtual string OrganizerContactInfo { get; set; }                

        public virtual string City { get; set; }

        public virtual string State { get; set; }
    }
}

