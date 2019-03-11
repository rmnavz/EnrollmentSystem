using EnrollmentSystem.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Model
{
    public class AccountInformationModel : ModelBase
    {
        public byte[] ProfileImage { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public GenderEnum Gender { get; set; }

        public virtual AccountModel Account { get; set; }
    }
}
