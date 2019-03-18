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
    [Authorize(Roles = "Administrator")]
    public class SubjectManagementController : ControllerBase
    {
        public SubjectManagementController(ISubjectService SubjectService)
        {
            _SubjectService = SubjectService;
        }

        // GET: SubjectManagement
        public ActionResult Index()
        {
            return View(
                    _SubjectService.GetSubjects(_SearchQuery).Where(x => x.Removed == null).ToList().ToSubjectViewModel()
                );
        }

        public ActionResult Create()
        {
            _DynamicModalOptions = new DynamicModalOptions
            {
                Title = "Create Subject",
                FormMethod = FormMethod.Post,
                FormType = FormType.Create
            };
            return ViewModal(
                    new SubjectModel().ToCreateSubjectFormViewModel(_SubjectService.GetSubjects().Where(x => x.Removed == null).ToList()), 
                    _DynamicModalOptions
                );
        }

        [HttpPost]
        public ActionResult Create(CreateSubjectFormViewModel Model)
        {
            _DynamicModalOptions = new DynamicModalOptions
            {
                Title = "Create Subject",
                FormMethod = FormMethod.Post,
                FormType = FormType.Create
            };

            if (!ModelState.IsValid) { return ViewModal(Model, _DynamicModalOptions); }

            SubjectModel Subject = Model.ToSubjectModel(_SubjectService.GetSubjects().Where(x => x.Removed == null).ToList());

            if (_SubjectService.GetSubject(Subject.Code) != null) { return ViewModal(Model, _DynamicModalOptions); }

            try
            {
                _SubjectService.CreateSubject(Subject);
                _SubjectService.SaveSubject();

                return ModalMessage("Dialog Message", "Subject created successfully");
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
                Title = "Edit Subject",
                FormMethod = FormMethod.Post,
                FormType = FormType.Edit
            };

            return ViewModal(
                    _SubjectService.GetSubject(ID).ToEditSubjectFormViewModel(_SubjectService.GetSubjects().Where(x => x.Removed == null).ToList()),
                    _DynamicModalOptions
                );
        }

        [HttpPost]
        public ActionResult Edit(EditSubjectFormViewModel Model)
        {
            _DynamicModalOptions = new DynamicModalOptions
            {
                Title = "Edit Subject",
                FormMethod = FormMethod.Post,
                FormType = FormType.Edit
            };

            if (!ModelState.IsValid) { return ViewModal(Model, _DynamicModalOptions); }

            SubjectModel Subject = Model.ToSubjectModel(_SubjectService.GetSubjects().Where(x => x.Removed == null).ToList(), _SubjectService.GetSubject(Model.ID));

            try
            {
                _SubjectService.UpdateSubject(Subject);
                _SubjectService.SaveSubject();

                return ModalMessage("Dialog Message", "Subject saved successfully");
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
                _SubjectService.SoftRemoveSubject(_SubjectService.GetSubject(ID));
                _SubjectService.SaveSubject();

                return ModalMessage("Dialog Message", "Subject removed successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return ModalMessage("Dialog Message", "Something went wrong");
            }

        }

        public ActionResult Recover(int ID)
        {
            _SubjectService.RecoverSubject(_SubjectService.GetSubject(ID));
            _SubjectService.SaveSubject();

            return ModalMessage("Dialog Message", "Subject Recovered");
        }
    }
}