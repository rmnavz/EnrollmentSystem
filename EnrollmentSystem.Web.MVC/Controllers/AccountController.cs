using AutoMapper;
using EnrollmentSystem.Mapping.Mappings;
using EnrollmentSystem.Model;
using EnrollmentSystem.Service;
using EnrollmentSystem.ViewModels;
using System;
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
        public ActionResult Index() => View(_AccountService.GetAccount(GetUserID()).ToAccountViewModel());

        public ActionResult ProfileImage() => base.File(_AccountService.GetAccount(GetUserID()).AccountInformation.ProfileImage, "image/jpg");

        public ActionResult Edit()
        {
            _DynamicModalOptions = new DynamicModalOptions
            {
                Title = "Edit Account",
                FormMethod = FormMethod.Post,
                FormType = FormType.Edit
            };
            return ViewModal(_AccountService.GetAccount(GetUserID()).ToEditAccountFormViewModel(), _DynamicModalOptions);
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

            AccountModel Account = Model.ToAccountModel(_AccountService.GetAccount(GetUserID()));

            try
            {
                _AccountService.UpdateAccount(Account);
                _AccountService.SaveAccount();

                return ModalMessage("Dialog Message", "Account saved successfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return ModalMessage("Dialog Message", "Something went wrong");
            }

        }
    }
}