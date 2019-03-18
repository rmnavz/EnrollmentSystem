using EnrollmentSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.ViewModels
{
    public class DepartmentViewModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<AccountModel> Accounts { get; set; }
        public ICollection<SubjectModel> Subjects { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Last Modified")]
        public DateTime? Modified { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Removed { get; set; }
    }
}
