using AutoMapper;
using EnrollmentSystem.Common.Helpers;
using EnrollmentSystem.Model;
using EnrollmentSystem.Service;
using EnrollmentSystem.Web.MVC.Common.PartialModels;
using EnrollmentSystem.Web.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EnrollmentSystem.Web.MVC.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class AccountManagementController : ControllerBase
    {
        public AccountManagementController(IAccountService AccountService)
        {
            _AccountService = AccountService;
        }
        // GET: AccountManagement
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<AccountModel>,IEnumerable<AccountViewModel>>(_AccountService.GetAccounts()));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateAccountFormViewModel Model)
        {
            if (!ModelState.IsValid) { return View(Model); }

            AccountModel Account = Mapper.Map<CreateAccountFormViewModel, AccountModel>(Model);

            if (_AccountService.GetAccount(Account.EmailAddress) != null) { return View("Index", Model); }

            _AccountService.CreateAccount(Account);
            _AccountService.SaveAccount();

            try
            {
                var Email = new EmailHelper();
                Email.NewAccountTemplate();
                await Email.SendMail("New Acccount Created", Account.EmailAddress);

                return PartialView("Partials/_MessageModal", new MessageModal()
                {
                    Title = "Dialog Message",
                    Message = "Account saved successfully"
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return PartialView("Partials/_MessageModal", new MessageModal()
                {
                    Title = "Dialog Message",
                    Message = "Something went wrong"
                });
            }
        }

        public ActionResult Remove(int ID)
        {
            _AccountService.RemoveAccount(_AccountService.GetAccount(ID));
            _AccountService.SaveAccount();

            return RedirectToAction("Index", "AccountManagement");
        }

        public ActionResult Recover(int ID)
        {
            _AccountService.RecoverAccount(_AccountService.GetAccount(ID));
            _AccountService.SaveAccount();

            return RedirectToAction("Index", "AccountManagement");
        }
    }
}