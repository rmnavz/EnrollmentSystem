using System;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentSystem.Web.MVC.ViewModels
{
    public class SubjectViewModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Unit { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Last Modified")]
        public DateTime? Modified { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Removed { get; set; }
    }
}