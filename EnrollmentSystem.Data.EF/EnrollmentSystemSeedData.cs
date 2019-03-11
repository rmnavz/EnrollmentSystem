using EnrollmentSystem.Common.Code.Conversion;
using EnrollmentSystem.Common.Code.Security;
using EnrollmentSystem.Common.Enums;
using EnrollmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Data.EF
{
    public class EnrollmentSystemSeedData : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            GetAccounts().ForEach(a => context.Accounts.Add(a));
            context.Commit();
            GetAccountInformations(context.Accounts.ToList()).ForEach(i => context.AccountInformation.Add(i));
            context.Commit();

        }

        private static List<AccountModel> GetAccounts()
        {
            byte[] GeneratedSalt = PasswordHasher.GenerateSalt();
            return new List<AccountModel>
            {
                new AccountModel {
                    ID = 1,
                    EmailAddress = "root@domain.com",
                    Password = PasswordHasher.ComputeHash("!root0", GeneratedSalt),
                    Salt = GeneratedSalt,
                    AccountType = AccountTypeEnum.Administrator,
                    Created = DateTime.UtcNow,
                },
                new AccountModel {
                    ID = 2,
                    EmailAddress = "rmnavz@domain.com",
                    Password = PasswordHasher.ComputeHash("override", GeneratedSalt),
                    Salt = GeneratedSalt,
                    AccountType = AccountTypeEnum.User,
                    Created = DateTime.UtcNow,
                },
            };
        }

        private static List<AccountInformationModel> GetAccountInformations(List<AccountModel> Accounts)
        {
            return new List<AccountInformationModel>
            {
                new AccountInformationModel
                {
                        ID = 1,
                        FirstName = "root",
                        LastName = "",
                        ProfileImage = new WebClient().DownloadData("https://proxy.duckduckgo.com/iu/?u=http%3A%2F%2Fwww.newdesignfile.com%2Fpostpic%2F2014%2F07%2Fgeneric-profile-avatar_352864.jpg&f=1"),
                        Gender = GenderEnum.Other,
                        Account = Accounts.Where(x => x.ID == 1).FirstOrDefault(),
                        Created = DateTime.UtcNow,

                },
                new AccountInformationModel
                {
                        ID = 2,
                        FirstName = "Rustom Miguel",
                        LastName = "Nava",
                        ProfileImage = new WebClient().DownloadData("https://proxy.duckduckgo.com/iu/?u=http%3A%2F%2Fwww.newdesignfile.com%2Fpostpic%2F2014%2F07%2Fgeneric-profile-avatar_352864.jpg&f=1"),
                        Gender = GenderEnum.Male,
                        Account = Accounts.Where(x => x.ID == 2).FirstOrDefault(),
                        Created = DateTime.UtcNow,

                }
            };
        }
    }
}
