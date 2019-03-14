using EnrollmentSystem.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Model
{
    public class AccountModel : ModelBase
    {
        public string EmailAddress { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public AccountTypeEnum AccountType { get; set; }

        public virtual AccountInformationModel AccountInformation { get; set; }
        public virtual DepartmentModel Department { get; set; }
    }
}
