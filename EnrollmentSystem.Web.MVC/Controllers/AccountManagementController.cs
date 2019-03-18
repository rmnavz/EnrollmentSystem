using AutoMapper;
using EnrollmentSystem.Mapping.Mappings;
using EnrollmentSystem.Model;
using EnrollmentSystem.Service;
using EnrollmentSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Index() => View(_AccountService.GetAccounts(_SearchQuery).Where(x => x.Removed == null).ToList().ToAccountViewModel());

        public ActionResult Create()
        {
            _DynamicModalOptions = new DynamicModalOptions
            {
                Title = "Create Account",
                FormMethod = FormMethod.Post,
                FormType = FormType.Create
            };
            return ViewModal(_DynamicModalOptions);
        }

        [HttpPost]
        public ActionResult Create(CreateAccountFormViewModel Model)
        {
            _DynamicModalOptions = new DynamicModalOptions
            {
                Title = "Create Account",
                FormMethod = FormMethod.Post,
                FormType = FormType.Create
            };

            if (!ModelState.IsValid) { return ViewModal(Model, _DynamicModalOptions); }

            AccountModel Account = Model.ToAccountModel();

            if (_AccountService.GetAccount(Account.EmailAddress) != null) { return ViewModal(Model, _DynamicModalOptions); }

            try
            {
                _AccountService.CreateAccount(Account);
                _AccountService.SaveAccount();

                return ModalMessage("Dialog Message", "Account created successfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return ModalMessage("Dialog Message", "Something went wrong");
            }
        }

        public ActionResult Edit(int ID)
        {
            _DynamicModalOptions = new DynamicModalOptions
            {
                Title = "Edit Account",
                FormMethod = FormMethod.Post,
                FormType = FormType.Edit
            };
            return ViewModal(_AccountService.GetAccount(ID).ToEditAccountFormViewModel(), _DynamicModalOptions);
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

            AccountModel Account = Model.ToAccountModel(_AccountService.GetAccount(Model.ID));

            try
            {
                _AccountService.UpdateAccount(Account);
                _AccountService.SaveAccount();

                return ModalMessage("Dialog Message", "Account saved successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return ModalMessage("Dialog Message", "Something went wrong");
            }
        }

        public ActionResult Remove(int ID)
        {
            try
            {
                _AccountService.SoftRemoveAccount(_AccountService.GetAccount(ID));
                _AccountService.SaveAccount();

                return ModalMessage("Dialog Message", "Account removed successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return ModalMessage("Dialog Message", "Something went wrong");
            }

        }

        public ActionResult Recover(int ID)
        {
            _AccountService.RecoverAccount(_AccountService.GetAccount(ID));
            _AccountService.SaveAccount();

            return ModalMessage("Dialog Message", "Account Recovered");
        }
    }
}