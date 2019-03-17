using AutoMapper;
using EnrollmentSystem.Model;
using EnrollmentSystem.Service;
using EnrollmentSystem.Web.MVC.Common.PartialModels;
using EnrollmentSystem.Web.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EnrollmentSystem.Web.MVC.Controllers
{
    public class SubjectManagementController : ControllerBase
    {
        public SubjectManagementController(ISubjectService SubjectService)
        {
            _SubjectService = SubjectService;
        }

        // GET: SubjectManagement
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<SubjectModel>,IEnumerable<SubjectViewModel>>(_SubjectService.GetSubjects(_SearchQuery).Where(x => x.Removed == null).ToList()));
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
                new CreateSubjectFormViewModel() {
                    AllSubjects = _SubjectService.GetSubjects().Where(x => x.Removed == null).ToList(),
                    PrerequisiteIDs = new List<int>() },
                _DynamicModalOptions);
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

            SubjectModel Subject = Mapper.Map<CreateSubjectFormViewModel, SubjectModel>(Model);

            Subject.Prerequisites = new List<SubjectModel>();
            foreach(var PrerequisiteID in Model.PrerequisiteIDs)
            {
                Subject.Prerequisites.Add(_SubjectService.GetSubject(PrerequisiteID));
            }

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

            SubjectModel Model = _SubjectService.GetSubject(ID);

            EditSubjectFormViewModel ViewModel = Mapper.Map<SubjectModel, EditSubjectFormViewModel>(Model);
            ViewModel.PrerequisiteIDs = new List<int>();
            foreach(var Prereqisite in Model.Prerequisites)
            {
                ViewModel.PrerequisiteIDs.Add(Prereqisite.ID);
            }
            ViewModel.AllSubjects = _SubjectService.GetSubjects().Where(x => x.Removed == null && x.ID != ViewModel.ID).ToList();

            return ViewModal( ViewModel, _DynamicModalOptions);
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

            SubjectModel Subject = _SubjectService.GetSubject(Model.ID);
            Mapper.Map(Model, Subject);

            Subject.Prerequisites = new List<SubjectModel>();
            foreach (var PrerequisiteID in Model.PrerequisiteIDs)
            {
                Subject.Prerequisites.Add(_SubjectService.GetSubject(PrerequisiteID));
            }

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

            return ModalMessage("Dialog Message", "Account Recovered");
        }
    }
}