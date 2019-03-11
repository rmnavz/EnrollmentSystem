using EnrollmentSystem.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace EnrollmentSystem.Web.MVC.ViewModels
{
    public class AccountViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        public Image ProfileImage { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "Not Provided")]
        public string BirthDate { get; set; }
        public GenderEnum Gender { get; set; }
        public AccountTypeEnum AccountType { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Last Modified")]
        public DateTime? Modified { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Removed { get; set; }

    }
}