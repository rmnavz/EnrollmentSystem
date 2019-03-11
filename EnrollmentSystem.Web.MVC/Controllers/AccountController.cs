using AutoMapper;
using EnrollmentSystem.Model;
using EnrollmentSystem.Service;
using EnrollmentSystem.Web.MVC.Common.PartialModels;
using EnrollmentSystem.Web.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnrollmentSystem.Web.MVC.Controllers
{
    [Authorize]
    public class AccountController : ControllerBase
    {

        public AccountController(IAccountService AccountService)
        {
            _AccountService = AccountService;
        }

        // GET: Account
        public ActionResult Index()
        {
            AccountModel Account = _AccountService.GetAccount(GetUserID());
            return View(Mapper.Map<AccountModel, AccountViewModel>(Account));
        }

        public ActionResult ProfileImage() => base.File(_AccountService.GetAccount(GetUserID()).AccountInformation.ProfileImage, "image/jpg");

        public ActionResult Edit()
        {
            AccountModel Account = _AccountService.GetAccount(GetUserID());
            return View(Mapper.Map<AccountModel, EditAccountFormViewModel>(Account));
        }

        [HttpPost]
        public ActionResult Edit(EditAccountFormViewModel Model)
        {
            if (!ModelState.IsValid) { return View(Model); }

            AccountModel Account = _AccountService.GetAccount(GetUserID());

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
    }
}