using EnrollmentSystem.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentSystem.Web.MVC.ViewModels
{
    public class RegisterFormViewModel
    {
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Gender")]
        public GenderEnum Gender { get; set; }

        [Display(Name = "Account Type")]
        public AccountTypeEnum AccountType { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [System.Web.Mvc.Remote("CheckExistingEmail", "Register", HttpMethod = "POST", ErrorMessage = "Email already exists")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Confirm Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password and Confirm Password doesn't match")]
        public string ConfirmPassword { get; set; }
    }
}