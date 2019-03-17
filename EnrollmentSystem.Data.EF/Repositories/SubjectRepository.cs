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

        public IEnumerable<SubjectModel> GetPrerequisitesBySubjectID(int ID)
        {
            return this.DbContext.Subjects
                .Include(x => x.Prerequisites)
                .Where(x => x.ID == ID).FirstOrDefault()
                .Prerequisites.ToList();
        }

        public SubjectModel GetSubjectByCode(string Code)
        {
            return this.DbContext.Subjects.Where(x => x.Code == Code).FirstOrDefault();
        }

        public override IEnumerable<SubjectModel> GetAll()
        {
            return this.DbContext.Subjects
                .Include(x => x.Prerequisites)
                .Include(x => x.Requisites)
                .ToList();
        }

        public override IEnumerable<SubjectModel> GetMany(Expression<Func<SubjectModel, bool>> where)
        {
            return this.DbContext.Subjects
                .Where(where)
                .Include(x => x.Prerequisites)
                .Include(x => x.Requisites)
                .ToList();
        }
    }

    public interface ISubjectRepository : IRepository<SubjectModel>
    {
        SubjectModel GetSubjectByCode(string Code);
        IEnumerable<SubjectModel> GetPrerequisitesBySubjectID(int ID);
    }
}
