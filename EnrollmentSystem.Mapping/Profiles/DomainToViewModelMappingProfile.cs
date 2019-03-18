using AutoMapper;
using EnrollmentSystem.Model;
using EnrollmentSystem.ViewModels;

namespace EnrollmentSystem.Mapping.Profiles
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            #region AccountModel

            CreateMap<AccountModel, AccountViewModel>()
                .ForMember(g => g.ID, map => map.MapFrom(vm => vm.ID))
                .ForMember(g => g.FirstName, map => map.MapFrom(vm => vm.AccountInformation.FirstName))
                .ForMember(g => g.LastName, map => map.MapFrom(vm => vm.AccountInformation.LastName))
                .ForMember(g => g.EmailAddress, map => map.MapFrom(vm => vm.EmailAddress))
                .ForMember(g => g.Gender, map => map.MapFrom(vm => vm.AccountInformation.Gender))
                .ForMember(g => g.AccountType, map => map.MapFrom(vm => vm.AccountType))
                .ForMember(g => g.Department, map => map.MapFrom(vm => vm.Department))
                .ForMember(g => g.Created, map => map.MapFrom(vm => vm.Created))
                .ForMember(g => g.Modified, map => map.MapFrom(vm => vm.Modified))
                .ForMember(g => g.Removed, map => map.MapFrom(vm => vm.Removed));

            CreateMap<AccountModel, EditAccountFormViewModel>()
                .ForMember(g => g.ID, map => map.MapFrom(vm => vm.AccountInformation.ID))
                .ForMember(g => g.FirstName, map => map.MapFrom(vm => vm.AccountInformation.FirstName))
                .ForMember(g => g.LastName, map => map.MapFrom(vm => vm.AccountInformation.LastName))
                .ForMember(g => g.EmailAddress, map => map.MapFrom(vm => vm.EmailAddress))
                .ForMember(g => g.BirthDate, map => map.MapFrom(vm => vm.AccountInformation.BirthDate))
                .ForMember(g => g.Gender, map => map.MapFrom(vm => vm.AccountInformation.Gender))
                .ForMember(g => g.AccountType, map => map.MapFrom(vm => vm.AccountType));

            #endregion

            #region SubjectModel

            CreateMap<SubjectModel, SubjectViewModel>()
                .ForMember(g => g.ID, map => map.MapFrom(vm => vm.ID))
                .ForMember(g => g.Code, map => map.MapFrom(vm => vm.Code))
                .ForMember(g => g.Title, map => map.MapFrom(vm => vm.Title))
                .ForMember(g => g.Description, map => map.MapFrom(vm => vm.Description))
                .ForMember(g => g.Unit, map => map.MapFrom(vm => vm.Unit))
                .ForMember(g => g.Lecture, map => map.MapFrom(vm => vm.Lecture))
                .ForMember(g => g.Laboratory, map => map.MapFrom(vm => vm.Laboratory))
                .ForMember(g => g.Created, map => map.MapFrom(vm => vm.Created))
                .ForMember(g => g.Modified, map => map.MapFrom(vm => vm.Modified))
                .ForMember(g => g.Removed, map => map.MapFrom(vm => vm.Removed));

            CreateMap<SubjectModel, CreateSubjectFormViewModel>()
                .ForMember(g => g.Code, map => map.MapFrom(vm => vm.Code))
                .ForMember(g => g.Title, map => map.MapFrom(vm => vm.Title))
                .ForMember(g => g.Description, map => map.MapFrom(vm => vm.Description))
                .ForMember(g => g.Unit, map => map.MapFrom(vm => vm.Unit))
                .ForMember(g => g.Lecture, map => map.MapFrom(vm => vm.Lecture))
                .ForMember(g => g.Laboratory, map => map.MapFrom(vm => vm.Laboratory));

            CreateMap<SubjectModel, EditSubjectFormViewModel>()
                .ForMember(g => g.Code, map => map.MapFrom(vm => vm.Code))
                .ForMember(g => g.Title, map => map.MapFrom(vm => vm.Title))
                .ForMember(g => g.Description, map => map.MapFrom(vm => vm.Description))
                .ForMember(g => g.Unit, map => map.MapFrom(vm => vm.Unit))
                .ForMember(g => g.Lecture, map => map.MapFrom(vm => vm.Lecture))
                .ForMember(g => g.Laboratory, map => map.MapFrom(vm => vm.Laboratory));

            #endregion

            #region DepartmentModel

            CreateMap<DepartmentModel, DepartmentViewModel>()
                .ForMember(g => g.ID, map => map.MapFrom(vm => vm.ID))
                .ForMember(g => g.Code, map => map.MapFrom(vm => vm.Code))
                .ForMember(g => g.Title, map => map.MapFrom(vm => vm.Title))
                .ForMember(g => g.Description, map => map.MapFrom(vm => vm.Description))
                .ForMember(g => g.Created, map => map.MapFrom(vm => vm.Created))
                .ForMember(g => g.Modified, map => map.MapFrom(vm => vm.Modified))
                .ForMember(g => g.Removed, map => map.MapFrom(vm => vm.Removed));

            CreateMap<DepartmentModel, CreateDepartmentFormViewModel>()
                .ForMember(g => g.Code, map => map.MapFrom(vm => vm.Code))
                .ForMember(g => g.Title, map => map.MapFrom(vm => vm.Title))
                .ForMember(g => g.Description, map => map.MapFrom(vm => vm.Description));

            CreateMap<DepartmentModel, EditDepartmentFormViewModel>()
                .ForMember(g => g.Code, map => map.MapFrom(vm => vm.Code))
                .ForMember(g => g.Title, map => map.MapFrom(vm => vm.Title))
                .ForMember(g => g.Description, map => map.MapFrom(vm => vm.Description));

            CreateMap<DepartmentModel, EditDepartmentAccountFormViewModel>()
                .ForMember(g => g.Code, map => map.MapFrom(vm => vm.Code))
                .ForMember(g => g.Title, map => map.MapFrom(vm => vm.Title))
                .ForMember(g => g.Description, map => map.MapFrom(vm => vm.Description));

            #endregion


        }
    }
}
