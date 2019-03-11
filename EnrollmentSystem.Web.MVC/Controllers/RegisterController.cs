using AutoMapper;
using EnrollmentSystem.Common.Code.Security;
using EnrollmentSystem.Common.Enums;
using EnrollmentSystem.Model;
using EnrollmentSystem.Service;
using EnrollmentSystem.Web.MVC.Common.Filters;
using EnrollmentSystem.Web.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnrollmentSystem.Web.MVC.Controllers
{
    [GuestOnly]
    [AllowAnonymous]
    public class RegisterController : ControllerBase
    {
        public RegisterController(IAccountService AccountService)
        {
            _AccountService = AccountService;
        }

        // GET: Register
        public ActionResult Index() => View(new RegisterFormViewModel() { AccountType = AccountTypeEnum.User });

        [HttpPost]
        public ActionResult Register(RegisterFormViewModel Model)
        {
            if (!ModelState.IsValid) { return View("Index", Model); }

            AccountModel Account = Mapper.Map<RegisterFormViewModel, AccountModel>(Model);

            if (PasswordHasher.VerifyPassword(Model.Password, Account.Salt, Account.Password))
            {
                if (_AccountService.GetAccount(Account.EmailAddress) != null) { return View("Index", Model); }

                _AccountService.CreateAccount(Account);
                _AccountService.SaveAccount();

                return RedirectToAction("Index", "Login");
            }

            return View("Index", Model);
        }

        [HttpPost]
        public JsonResult CheckExistingEmail(string EmailAddress) => Json(!IsEmailExist(EmailAddress), JsonRequestBehavior.AllowGet);
    }
}