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
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateSubjectFormViewModel Model)
        {
            if (!ModelState.IsValid) { return View(Model); }

            SubjectModel Subject = Mapper.Map<CreateSubjectFormViewModel, SubjectModel>(Model);

            if (_SubjectService.GetSubject(Subject.Code) != null) { return View("Index", Model); }

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
    }
}