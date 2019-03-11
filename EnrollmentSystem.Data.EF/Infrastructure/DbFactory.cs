using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Data.EF.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        DatabaseContext dbContext;

        public DatabaseContext Init()
        {
            return dbContext ?? (dbContext = new DatabaseContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
