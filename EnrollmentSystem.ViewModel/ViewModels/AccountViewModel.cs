using EnrollmentSystem.Common.Enums;
using EnrollmentSystem.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentSystem.ViewModels
{
    public class AccountViewModel
    {
        public AccountViewModel()
        {
            this.Department = new DepartmentModel();
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        public string ProfileImage { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "Not Provided")]
        public string BirthDate { get; set; }
        public GenderEnum Gender { get; set; }
        public AccountTypeEnum AccountType { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "None")]
        public DepartmentModel Department { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Last Modified")]
        public DateTime? Modified { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Removed { get; set; }

    }
}