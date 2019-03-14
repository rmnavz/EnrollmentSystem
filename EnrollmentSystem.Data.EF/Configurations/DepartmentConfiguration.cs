using EnrollmentSystem.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace EnrollmentSystem.Data.EF.Configurations
{
    public class DepartmentConfiguration : EntityTypeConfiguration<DepartmentModel>
    {
        public DepartmentConfiguration()
        {
            ToTable("Departments");
            Property(x => x.Code).IsRequired().HasMaxLength(450).HasColumnAnnotation("Index", new IndexAnnotation(new[] { new IndexAttribute("Index") { IsUnique = true } }));
        }
    }
}
