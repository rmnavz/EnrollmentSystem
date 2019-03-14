using EnrollmentSystem.Data.EF.Infrastructure;
using EnrollmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EnrollmentSystem.Data.EF.Repositories
{
    public class SubjectRepository : RepositoryBase<SubjectModel>, ISubjectRepository
    {
        public SubjectRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public SubjectModel GetSubjectByCode(string Code)
        {
            return this.DbContext.Subjects.Where(x => x.Code == Code).FirstOrDefault();
        }
    }

    public interface ISubjectRepository : IRepository<SubjectModel>
    {
        SubjectModel GetSubjectByCode(string Code);
    }
}
