using EnrollmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Data.EF.Configurations
{
    class AccountInformationConfiguration : EntityTypeConfiguration<AccountInformationModel>
    {
        public AccountInformationConfiguration()
        {
            ToTable("AccountInformations");

            Property(x => x.BirthDate)
                .HasColumnType("date");
        }
    }
}
