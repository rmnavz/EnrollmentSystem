using EnrollmentSystem.Common.Code.Security;
using EnrollmentSystem.Data.EF.Infrastructure;
using EnrollmentSystem.Data.EF.Repositories;
using EnrollmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Net;

namespace EnrollmentSystem.Service
{
    public interface IAccountService
    {
        AccountModel Login(string emailAddress, string password);
        bool IsEmailExist(string EmailAddress);
        IEnumerable<AccountModel> GetAccounts();
        IEnumerable<AccountModel> GetAccounts(string keyword);
        AccountModel GetAccount(int id);
        AccountModel GetAccount(string emailAddress);
        void CreateAccount(AccountModel account);
        void UpdateAccount(AccountModel account);
        void SoftRemoveAccount(AccountModel account);
        void RemoveAccount(AccountModel account);
        void RecoverAccount(AccountModel account);
        void SaveAccount();
    }

    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IUnitOfWork unitOfWork;

        public AccountService(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
            this.accountRepository = accountRepository;
            this.unitOfWork = unitOfWork;
        }

        public AccountModel Login(string emailAddress, string password)
        {
            AccountModel Account = accountRepository.GetAccountByEmailAddress(emailAddress);
            if(PasswordHasher.VerifyPassword(password, Account.Salt, Account.Password) && Account.Removed == null)
            {
                return Account;
            }

            return null;
            
        }

        public bool IsEmailExist(string EmailAddress)
        {
            return accountRepository.IsEmailExist(EmailAddress);
        }

        public void CreateAccount(AccountModel account)
        {
            account.AccountInformation.ProfileImage = new WebClient().DownloadData("https://proxy.duckduckgo.com/iu/?u=http%3A%2F%2Fwww.newdesignfile.com%2Fpostpic%2F2014%2F07%2Fgeneric-profile-avatar_352864.jpg&f=1");
            accountRepository.Add(account);
        }

        public void UpdateAccount(AccountModel account)
        {
            accountRepository.Update(account);
        }

        public void SoftRemoveAccount(AccountModel account)
        {
            account.Removed = DateTime.UtcNow;
            accountRepository.Update(account);
        }

        public void RemoveAccount(AccountModel account)
        {
            accountRepository.Delete(account);
        }

        public void RecoverAccount(AccountModel account)
        {
            account.Removed = null;
            accountRepository.Update(account);
        }

        public IEnumerable<AccountModel> GetAccounts()
        {
            return accountRepository.GetAll();
        }

        public IEnumerable<AccountModel> GetAccounts(string keyword)
        {
            if(string.IsNullOrEmpty(keyword))
            {
                return GetAccounts();
            }
            else
            {
                return accountRepository.GetMany(x =>
                    x.EmailAddress.Contains(keyword) ||
                    x.AccountInformation.FirstName.Contains(keyword) ||
                    x.AccountInformation.LastName.Contains(keyword)
                );
            }
            
        }

        public AccountModel GetAccount(int id)
        {
            return accountRepository.GetById(id);
        }

        public AccountModel GetAccount(string emailAddress)
        {
            return accountRepository.GetAccountByEmailAddress(emailAddress);
        }

        public void SaveAccount()
        {
            unitOfWork.Commit();
        }
    }
}
