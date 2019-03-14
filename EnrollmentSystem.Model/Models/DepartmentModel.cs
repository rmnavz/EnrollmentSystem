using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Model
{
    public class DepartmentModel : ModelBase
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AccountModel> Accounts { get; set; }
        public virtual ICollection<SubjectModel> Subjects { get; set; }
    }
}
