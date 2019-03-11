using EnrollmentSystem.Data.EF.Configurations;
using EnrollmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Data.EF
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base(@"Server=.\SQLEXPRESS;Database=db_EnrollmentSystem;Trusted_Connection=True;")
        {

        }

        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<AccountInformationModel> AccountInformation { get; set; }

        public virtual void Commit()
        {
            Audit();
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountConfiguration());
            modelBuilder.Configurations.Add(new AccountInformationConfiguration());
        }

        public void Audit()
        {
            var now = DateTime.UtcNow;

            foreach(var entity in ChangeTracker.Entries<ModelBase>().Where(x => x.State == EntityState.Added).Select(x => x.Entity))
            {
                entity.Created = now;
            }

            foreach (var entity in ChangeTracker.Entries<ModelBase>().Where(x => x.State == EntityState.Modified).Select(x => x.Entity))
            {
                entity.Modified = now;
            }

            foreach (var entity in ChangeTracker.Entries<ModelBase>().Where(x => x.State == EntityState.Deleted).Select(x => x.Entity))
            {
                entity.Removed = now;
            }
        }
    }
}
