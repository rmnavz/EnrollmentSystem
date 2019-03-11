using AutoMapper;
using EnrollmentSystem.Common.Code.Conversion;
using EnrollmentSystem.Model;
using EnrollmentSystem.Web.MVC.ViewModels;

namespace EnrollmentSystem.Web.MVC.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<AccountModel, AccountViewModel>()
                .ForMember(g => g.FirstName, map => map.MapFrom(vm => vm.AccountInformation.FirstName))
                .ForMember(g => g.LastName, map => map.MapFrom(vm => vm.AccountInformation.LastName))
                .ForMember(g => g.EmailAddress, map => map.MapFrom(vm => vm.EmailAddress))
                .ForMember(g => g.Gender, map => map.MapFrom(vm => vm.AccountInformation.Gender))
                .ForMember(g => g.AccountType, map => map.MapFrom(vm => vm.AccountType))
                .ForMember(g => g.Created, map => map.MapFrom(vm => vm.Created))
                .ForMember(g => g.Modified, map => map.MapFrom(vm => vm.Modified))
                .ForMember(g => g.Removed, map => map.MapFrom(vm => vm.Removed))
                .BeforeMap(
                    (Model, ViewModel) => ViewModel.BirthDate = Model.AccountInformation.BirthDate != null ? Model.AccountInformation.BirthDate.Value.ToString("MMMM d, yyyy") : null
                )
                .AfterMap(
                    (Model, ViewModel) => ViewModel.ProfileImage = Model.AccountInformation.ProfileImage != null ? new Conversion().ByteArrayToImage(Model.AccountInformation.ProfileImage) : null
                );

            CreateMap<AccountModel, EditAccountFormViewModel>()
                .ForMember(g => g.FirstName, map => map.MapFrom(vm => vm.AccountInformation.FirstName))
                .ForMember(g => g.LastName, map => map.MapFrom(vm => vm.AccountInformation.LastName))
                .ForMember(g => g.EmailAddress, map => map.MapFrom(vm => vm.EmailAddress))
                .ForMember(g => g.BirthDate, map => map.MapFrom(vm => vm.AccountInformation.BirthDate))
                .ForMember(g => g.Gender, map => map.MapFrom(vm => vm.AccountInformation.Gender));
        }
    }
}