using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Team12FinalProject.Models
{
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
        [Display(Name = "Customer Number")]
        public Int32 CustomerNumber { get; set; }
        // Add any fields that you need for creating a new user

        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        //Additional fields go here
        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        // Here is the property for email
        [Required]
        [EmailAddress(ErrorMessage = "This email is invalid.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        // Here is the property for phone number
        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        // Here is the logic for putting in a password
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        

        [Display(Name = "Middle Initial")]
        public String MiddleInitial { get; set; }

        // [Required(ErrorMessage = "Please enter the birthday")]
        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }

        [Display(Name = "Initial")]
        public String Initial { get; set; }

        [Required(ErrorMessage = "Please enter the street name")]
        [Display(Name = "Street")]
        public String Street { get; set; }

        [Required(ErrorMessage = "Please enter the city name")]
        [Display(Name = "City")]
        public String City { get; set; }

        [Required(ErrorMessage = "Please enter the state")]
        [Display(Name = "State")]
        public String State { get; set; }

        [Required(ErrorMessage = "Please enter the zip code")]
        [Display(Name = "Zip Code")]
        public Int32 ZipCode { get; set; }

        [Display(Name = "SSN")]
        public String SSN { get; set; }

    }

    public class ChangeAccount
    {
        public string id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        //Additional fields go here
        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "This email is invalid.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        // Here is the property for phone number
        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter the street name")]
        [Display(Name = "Street")]
        public String Street { get; set; }

        [Required(ErrorMessage = "Please enter the city name")]
        [Display(Name = "City")]
        public String City { get; set; }

        [Required(ErrorMessage = "Please enter the state")]
        [Display(Name = "State")]
        public String State { get; set; }

        [Required(ErrorMessage = "Please enter the zip code")]
        [Display(Name = "Zip Code")]
        public Int32 ZipCode { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


    }

    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public String UserID { get; set; }

        public Int32 CustomerNumber { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String MiddleInitial { get; set; }

        public DateTime? Birthday { get; set; }

        public String Initial { get; set; }
        
        public String Street { get; set; }

        public String City { get; set; }

        public String State { get; set; }

        public Int32 ZipCode { get; set; }

        public String SSN { get; set; }
    }
}
