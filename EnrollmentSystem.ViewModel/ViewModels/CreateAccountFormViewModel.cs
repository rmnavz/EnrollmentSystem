using EnrollmentSystem.Common.Enums;
using EnrollmentSystem.Model;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentSystem.ViewModels
{
    public class CreateAccountFormViewModel
    {
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        //[System.Web.Mvc.Remote("CheckExistingEmail", "Register", HttpMethod = "POST", ErrorMessage = "Email already exists")]
        public string EmailAddress { get; set; }

        public GenderEnum Gender { get; set; }

        public AccountTypeEnum AccountType { get; set; }
        public AccountModel ToCreateAccountFormViewModel { get; set; }
    }
}