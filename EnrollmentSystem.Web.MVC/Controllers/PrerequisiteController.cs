using AutoMapper;
using EnrollmentSystem.Model;
using EnrollmentSystem.Service;
using EnrollmentSystem.Web.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnrollmentSystem.Web.MVC.Controllers
{
    public class PrerequisiteController : ControllerBase
    {
        public PrerequisiteController(ISubjectService SubjectService)
        {
            _SubjectService = SubjectService;
        }
        // GET: PrerequisiteManagement
        public ActionResult Add(int ID)
        {
            new DynamicModalOptions()
            {
                Title = "Create Subject",
                FormMethod = FormMethod.Post,
                FormType = FormType.Create
            };

            return ViewModal(Mapper.Map<IEnumerable<SubjectModel>, IEnumerable<SubjectViewModel>>(_SubjectService.GetSubjects(_SearchQuery).Where(x => x.Removed == null).ToList()), _DynamicModalOptions);
        }
    }
}