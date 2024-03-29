﻿using EnrollmentSystem.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace EnrollmentSystem.ViewModels
{
    public class EditAccountFormViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Profile Image")]
        public HttpPostedFileBase ProfileImage { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }
        public GenderEnum Gender { get; set; }
        public AccountTypeEnum AccountType { get; set; }
    }
}