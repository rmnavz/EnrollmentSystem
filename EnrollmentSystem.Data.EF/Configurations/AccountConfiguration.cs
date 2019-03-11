using EnrollmentSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Data.EF.Configurations
{
    public class AccountConfiguration : EntityTypeConfiguration<AccountModel>
    {

        public AccountConfiguration()
        {
            ToTable("Accounts");
            Property(x => x.EmailAddress).IsRequired().HasMaxLength(450).HasColumnAnnotation("Index", new IndexAnnotation(new[] { new IndexAttribute("Index") { IsUnique = true } }));

            HasOptional(x => x.AccountInformation)
                .WithRequired(x => x.Account);
        }

    }
}
