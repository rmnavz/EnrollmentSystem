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
            _DynamicModalOptions = new DynamicModalOptions
            {
                Title = "Edit Account",
                FormMethod = FormMethod.Post,
                FormType = FormType.Edit
            };
            AccountModel Account = _AccountService.GetAccount(GetUserID());
            return ViewModal(Mapper.Map<AccountModel, EditAccountFormViewModel>(Account), _DynamicModalOptions);
        }

        [HttpPost]
        public ActionResult Edit(EditAccountFormViewModel Model)
        {
            _DynamicModalOptions = new DynamicModalOptions
            {
                Title = "Edit Account",
                FormMethod = FormMethod.Post,
                FormType = FormType.Edit
            };

            if (!ModelState.IsValid) { return ViewModal(Model, _DynamicModalOptions); }

            AccountModel Account = _AccountService.GetAccount(GetUserID());

            Mapper.Map(Model, Account);

            try
            {
                _AccountService.UpdateAccount(Account);
                _AccountService.SaveAccount();

                return ModalMessage("Dialog Message", "Account saved successfully");
            }
            catch(Exception ex)
            {
                return ModalMessage("Dialog Message", "Something went wrong");
            }

        }
    }
}