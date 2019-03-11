using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Data.EF.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DatabaseContext Init();
    }
}
