using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace JFLatest.Models
{
    public class JobfairContext : DbContext
    {
        public JobfairContext()
            : base("name=jobfairContext")
        {
            
        }

    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }

        public string ExternalLoginData { get; set; }
    }
    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address, please check the format")]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterEmployer
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address, please check the format")]
        public string email { get; set; }
        

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string address { get; set; }

        [Required]
        [StringLength(10,MinimumLength=10, ErrorMessage = "The {0} field must be exactly {2} characters long.")]
        [Display(Name = "Contact Number")]
        [RegularExpression("([0][0-9]*)", ErrorMessage = "{0} must contain only numbers and start with 0")]
        public string contactNumber { get; set; }
        public string userType { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "The {0} field must be at least {2} characters long.")]
        [Display(Name = "Name")]
        public string  name { get; set; }


    }
}
