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
        public ActionResult Index() => View(Mapper.Map<IEnumerable<AccountModel>, IEnumerable<AccountViewModel>>(_AccountService.GetAccounts(_SearchQuery).Where(x => x.Removed == null).ToList()));

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateAccountFormViewModel Model)
        {
            if (!ModelState.IsValid) { return View(Model); }

            AccountModel Account = Mapper.Map<CreateAccountFormViewModel, AccountModel>(Model);

            if (_AccountService.GetAccount(Account.EmailAddress) != null) { return View("Index", Model); }

            _AccountService.CreateAccount(Account);
            _AccountService.SaveAccount();

            try
            {
                

                return PartialView("Partials/_MessageModal", new MessageModal()
                {
                    Title = "Dialog Message",
                    Message = "Account created successfully"
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

        public ActionResult Edit(int ID)
        {
            return View(Mapper.Map<AccountModel,EditAccountFormViewModel>(_AccountService.GetAccount(ID)));
        }

        [HttpPost]
        public ActionResult Edit(EditAccountFormViewModel Model)
        {
            if (!ModelState.IsValid) { return View(Model); }

            AccountModel Account = _AccountService.GetAccount(Model.EmailAddress);

            Mapper.Map(Model, Account);

            try
            {
                _AccountService.UpdateAccount(Account);
                _AccountService.SaveAccount();

                return PartialView("Partials/_MessageModal", new MessageModal()
                {
                    Title = "Dialog Message",
                    Message = "Account saved successfully"
                });
            }
            catch (Exception ex)
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
            try
            {
                _AccountService.RemoveAccount(_AccountService.GetAccount(ID));
                _AccountService.SaveAccount();

                return PartialView("Partials/_MessageModal", new MessageModal()
                {
                    Title = "Dialog Message",
                    Message = "Account removed successfully"
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return PartialView("Partials/_MessageModal", new MessageModal()
                {
                    Title = "Dialog Message",
                    Message = "Something went wrong"
                });
            }

        }

        public ActionResult Recover(int ID)
        {
            _AccountService.RecoverAccount(_AccountService.GetAccount(ID));
            _AccountService.SaveAccount();

            return RedirectToAction("Index", "AccountManagement");
        }
    }
}