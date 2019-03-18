using AutoMapper;
using EnrollmentSystem.Model;
using EnrollmentSystem.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace EnrollmentSystem.Mapping.Mappings
{
    public static class DepartmentModelMapper
    {
        public static DepartmentModel ToDepartmentModel(this CreateDepartmentFormViewModel ViewModel)
        {
            DepartmentModel Model = new DepartmentModel();
            Model = Mapper.Map<CreateDepartmentFormViewModel, DepartmentModel>(ViewModel);
            return Model;
        }

        public static DepartmentModel ToDepartmentModel(this EditDepartmentFormViewModel ViewModel, DepartmentModel Bind = null)
        {
            DepartmentModel Model = Bind ?? new DepartmentModel();
            Model = Mapper.Map(ViewModel, Model);
            return Model;
        }

        public static DepartmentModel ToDepartmentModel(this EditDepartmentAccountFormViewModel ViewModel, ICollection<AccountModel> Accounts, DepartmentModel Bind = null)
        {
            DepartmentModel Model = Bind ?? new DepartmentModel();
            Model = Mapper.Map(ViewModel, Model);
            ViewModel.SelectedIDs.ToList().ForEach(ID => Model.Accounts.Add(Accounts.FirstOrDefault(x => x.ID == ID)));
            return Model;
        }

        public static DepartmentViewModel ToDepartmentViewModel(this DepartmentModel Model)
        {
            DepartmentViewModel ViewModel = new DepartmentViewModel();
            ViewModel = Mapper.Map<DepartmentModel, DepartmentViewModel>(Model);
            return ViewModel;
        }

        public static IEnumerable<DepartmentViewModel> ToDepartmentViewModel(this IEnumerable<DepartmentModel> Model)
        {
            List<DepartmentViewModel> ViewModel = new List<DepartmentViewModel>();
            Model.ToList().ForEach(x => ViewModel.Add(x.ToDepartmentViewModel()));
            return ViewModel;
        }

        public static EditDepartmentFormViewModel ToEditDepartmentFormViewModel(this DepartmentModel Model)
        {
            EditDepartmentFormViewModel ViewModel = new EditDepartmentFormViewModel();
            ViewModel = Mapper.Map<DepartmentModel, EditDepartmentFormViewModel>(Model);
            return ViewModel;
        }

        public static EditDepartmentAccountFormViewModel ToEditDepartmentAccountFormViewModel(this DepartmentModel Model, ICollection<AccountModel> Accounts)
        {
            EditDepartmentAccountFormViewModel ViewModel = new EditDepartmentAccountFormViewModel();
            ViewModel = Mapper.Map<DepartmentModel, EditDepartmentAccountFormViewModel>(Model);
            ViewModel.Accounts = Accounts.Where(x => x.Department == null).ToList();
            Model.Accounts.ToList().ForEach(x => ViewModel.SelectedIDs.Add(x.ID));
            return ViewModel;
        }
    }
}
