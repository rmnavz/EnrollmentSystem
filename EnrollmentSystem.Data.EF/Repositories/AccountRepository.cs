using EnrollmentSystem.Common.Code.Security;
using EnrollmentSystem.Data.EF.Infrastructure;
using EnrollmentSystem.Model;
using System;
using System.Data.Entity;
using System.Linq;

namespace EnrollmentSystem.Data.EF.Repositories
{
    public class AccountRepository : RepositoryBase<AccountModel>, IAccountRepository
    {
        public AccountRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public AccountModel Login(AccountModel Account)
        {
            return this.DbContext.Accounts
                .Include(x => x.AccountInformation)
                .Where(x => x.EmailAddress == Account.EmailAddress)
                .FirstOrDefault();
        }

        public AccountModel GetAccountByEmailAddress(string EmailAddress)
        {
            return this.DbContext.Accounts.Where(x => x.EmailAddress == EmailAddress).FirstOrDefault();
        }

        public bool IsEmailExist(string EmailAddress)
        {
            return DbContext.Accounts.Where(x => x.EmailAddress == EmailAddress).Count() > 0 ? true : false;
        }
    }

    public interface IAccountRepository : IRepository<AccountModel>
    {
        AccountModel Login(AccountModel Account);
        AccountModel GetAccountByEmailAddress(string EmailAddress);
        bool IsEmailExist(string EmailAddress);
    }
}
