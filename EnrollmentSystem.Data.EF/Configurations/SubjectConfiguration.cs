using EnrollmentSystem.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace EnrollmentSystem.Data.EF.Configurations
{
    public class SubjectConfiguration : EntityTypeConfiguration<SubjectModel>
    {
        public SubjectConfiguration()
        {
            ToTable("Subjects");
            Property(x => x.Code).IsRequired().HasMaxLength(450).HasColumnAnnotation("Index", new IndexAnnotation(new[] { new IndexAttribute("Index") { IsUnique = true } }));

            HasOptional(x => x.Department)
                .WithMany(x => x.Subjects);

            HasMany(x => x.Prerequisites)
                .WithMany(x => x.Requisites);
        }
    }
}
