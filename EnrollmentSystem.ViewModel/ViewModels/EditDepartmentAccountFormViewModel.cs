using EnrollmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.ViewModels
{
    public class EditDepartmentAccountFormViewModel
    {
        public EditDepartmentAccountFormViewModel()
        {
            this.SelectedIDs = new List<int>();
        }

        public int ID { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<AccountModel> Accounts { get; set; }
        public ICollection<int> SelectedIDs { get; set; }
    }
}
