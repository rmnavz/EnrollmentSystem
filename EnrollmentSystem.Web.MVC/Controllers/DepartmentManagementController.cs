using EnrollmentSystem.Mapping.Mappings;
using EnrollmentSystem.Model;
using EnrollmentSystem.Service;
using EnrollmentSystem.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace EnrollmentSystem.Web.MVC.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class DepartmentManagementController : ControllerBase
    {
        public DepartmentManagementController(IDepartmentService DepartmentService, IAccountService AccountService)
        {
            _DepartmentService = DepartmentService;
            _AccountService = AccountService;
        }

        // GET: DepartmentManagement
        public ActionResult Index()
        {
            return View(
                    _DepartmentService.GetDepartments(_SearchQuery).Where(x => x.Removed == null).ToList().ToDepartmentViewModel()
                );
        }

        public ActionResult Create()
        {
            _DynamicModalOptions = new DynamicModalOptions
            {
                Title = "Create Department",
                FormMethod = FormMethod.Post,
                FormType = FormType.Create
            };
            return ViewModal(
                    _DynamicModalOptions
                );
        }

        [HttpPost]
        public ActionResult Create(CreateDepartmentFormViewModel Model)
        {
            _DynamicModalOptions = new DynamicModalOptions
            {
                Title = "Create Department",
                FormMethod = FormMethod.Post,
                FormType = FormType.Create
            };

            if (!ModelState.IsValid) { return ViewModal(Model, _DynamicModalOptions); }

            DepartmentModel Department = Model.ToDepartmentModel();

            if (_DepartmentService.GetDepartment(Department.Code) != null) { return ViewModal(Model, _DynamicModalOptions); }

            try
            {
                _DepartmentService.CreateDepartment(Department);
                _DepartmentService.SaveDepartment();

                return ModalMessage("Dialog Message", "Department created successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return ModalMessage("Dialog Message", "Something went wrong");
            }
        }

        public ActionResult Edit(int ID)
        {
            _DynamicModalOptions = new DynamicModalOptions
            {
                Title = "Edit Department",
                FormMethod = FormMethod.Post,
                FormType = FormType.Edit
            };

            return ViewModal(
                    _DepartmentService.GetDepartment(ID).ToEditDepartmentFormViewModel(),
                    _DynamicModalOptions
                );
        }

        [HttpPost]
        public ActionResult Edit(EditDepartmentFormViewModel Model)
        {
            _DynamicModalOptions = new DynamicModalOptions
            {
                Title = "Edit Department",
                FormMethod = FormMethod.Post,
                FormType = FormType.Edit
            };

            if (!ModelState.IsValid) { return ViewModal(Model, _DynamicModalOptions); }

            DepartmentModel Department = Model.ToDepartmentModel(_DepartmentService.GetDepartment(Model.ID));

            try
            {
                _DepartmentService.UpdateDepartment(Department);
                _DepartmentService.SaveDepartment();

                return ModalMessage("Dialog Message", "Department saved successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return ModalMessage("Dialog Message", "Something went wrong");
            }
        }

        public ActionResult EditAccounts(int ID)
        {
            _DynamicModalOptions = new DynamicModalOptions
            {
                Title = "Edit Accounts Department",
                FormMethod = FormMethod.Post,
                FormType = FormType.Edit
            };

            return ViewModal(
                    _DepartmentService.GetDepartment(ID).ToEditDepartmentAccountFormViewModel(_AccountService.GetAccounts().ToList()),
                    _DynamicModalOptions
                );
        }

        [HttpPost]
        public ActionResult EditAccounts(EditDepartmentAccountFormViewModel Model)
        {
            _DynamicModalOptions = new DynamicModalOptions
            {
                Title = "Edit Accounts Department",
                FormMethod = FormMethod.Post,
                FormType = FormType.Edit
            };

            if (!ModelState.IsValid) { return ViewModal(Model, _DynamicModalOptions); }

            DepartmentModel Department = Model.ToDepartmentModel(_AccountService.GetAccounts().ToList(), _DepartmentService.GetDepartment(Model.ID));

            try
            {
                _DepartmentService.UpdateDepartment(Department);
                _DepartmentService.SaveDepartment();

                return ModalMessage("Dialog Message", "Department saved successfully");
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
                _DepartmentService.SoftRemoveDepartment(_DepartmentService.GetDepartment(ID));
                _DepartmentService.SaveDepartment();

                return ModalMessage("Dialog Message", "Department removed successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return ModalMessage("Dialog Message", "Something went wrong");
            }

        }

        public ActionResult Recover(int ID)
        {
            _DepartmentService.RecoverDepartment(_DepartmentService.GetDepartment(ID));
            _DepartmentService.SaveDepartment();

            return ModalMessage("Dialog Message", "Department Recovered");
        }
    }
}