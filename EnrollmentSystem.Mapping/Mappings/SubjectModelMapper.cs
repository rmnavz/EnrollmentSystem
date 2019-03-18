using AutoMapper;
using EnrollmentSystem.Common.Code.Conversion;
using EnrollmentSystem.Model;
using EnrollmentSystem.Service;
using EnrollmentSystem.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace EnrollmentSystem.Mapping.Mappings
{
    public static class SubjectModelMapper
    {

        public static SubjectModel ToSubjectModel(this CreateSubjectFormViewModel ViewModel, ICollection<SubjectModel> Subjects)
        {
            SubjectModel Model = new SubjectModel();
            Model = Mapper.Map<CreateSubjectFormViewModel, SubjectModel>(ViewModel);
            ViewModel.PrerequisiteIDs.ToList().ForEach(ID => Model.Prerequisites.Add(Subjects.FirstOrDefault(x => x.ID == ID)));
            return Model;
        }

        public static SubjectModel ToSubjectModel(this EditSubjectFormViewModel ViewModel, ICollection<SubjectModel> Subjects, SubjectModel Bind = null)
        {
            SubjectModel Model = Bind ?? new SubjectModel();
            Model = Mapper.Map(ViewModel, Model);
            ViewModel.PrerequisiteIDs.ToList().ForEach(ID => Model.Prerequisites.Add(Subjects.FirstOrDefault(x => x.ID == ID)));
            return Model;
        }

        public static SubjectViewModel ToSubjectViewModel(this SubjectModel Model)
        {
            SubjectViewModel ViewModel = new SubjectViewModel();
            ViewModel = Mapper.Map<SubjectModel, SubjectViewModel>(Model);
            return ViewModel;
        }

        public static IEnumerable<SubjectViewModel> ToSubjectViewModel(this IEnumerable<SubjectModel> Model)
        {
            List<SubjectViewModel> ViewModel = new List<SubjectViewModel>();
            Model.ToList().ForEach(x => ViewModel.Add(x.ToSubjectViewModel()));
            return ViewModel;
        }

        public static CreateSubjectFormViewModel ToCreateSubjectFormViewModel(this SubjectModel Model, ICollection<SubjectModel> Subjects)
        {
            CreateSubjectFormViewModel ViewModel = new CreateSubjectFormViewModel();
            ViewModel = Mapper.Map<SubjectModel, CreateSubjectFormViewModel>(Model);
            ViewModel.AllSubjects = Subjects.ToList();
            return ViewModel;
        }

        public static EditSubjectFormViewModel ToEditSubjectFormViewModel(this SubjectModel Model, ICollection<SubjectModel> Subjects)
        {
            EditSubjectFormViewModel ViewModel = new EditSubjectFormViewModel();
            ViewModel = Mapper.Map<SubjectModel, EditSubjectFormViewModel>(Model);
            ViewModel.AllSubjects = Subjects.Where(x => x.ID != ViewModel.ID  && !Model.Requisites.Contains(x)).ToList();
            Model.Prerequisites.ToList().ForEach(x => ViewModel.PrerequisiteIDs.Add(x.ID));
            return ViewModel;
        }
    }
}
