using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Model
{
    public class SubjectModel : ModelBase
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Unit { get; set; }
        public bool Lecture { get; set; }
        public bool Laboratory { get; set; }

        public virtual DepartmentModel Department { get; set; }

        public virtual ICollection<SubjectModel> Requisites { get; set; }
        public virtual ICollection<SubjectModel> Prerequisites { get; set; }
    }
}
