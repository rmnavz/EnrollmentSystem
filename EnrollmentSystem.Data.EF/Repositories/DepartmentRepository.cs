using EnrollmentSystem.Data.EF.Infrastructure;
using EnrollmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EnrollmentSystem.Data.EF.Repositories
{
    public class DepartmentRepository : RepositoryBase<DepartmentModel>, IDepartmentRepository
    {
        public DepartmentRepository(IDbFactory dbFactory) 
            : base(dbFactory) { }

        public override IEnumerable<DepartmentModel> GetAll()
        {
            return this.DbContext.Departments
                .Include(x => x.Accounts)
                .Include(x => x.Subjects)
                .ToList();
        }

        public DepartmentModel GetDepartmentByCode(string Code)
        {
            return this.DbContext.Departments.Where(x => x.Code == Code).FirstOrDefault();
        }

        public override IEnumerable<DepartmentModel> GetMany(Expression<Func<DepartmentModel, bool>> where)
        {
            return this.DbContext.Departments
                .Where(where)
                .Include(x => x.Accounts)
                .Include(x => x.Subjects)
                .ToList();
        }
    }

    public interface IDepartmentRepository : IRepository<DepartmentModel>
    {
        DepartmentModel GetDepartmentByCode(string Code);
    }
}
