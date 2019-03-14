using AutoMapper;
using EnrollmentSystem.Common.Code.Security;
using EnrollmentSystem.Model;
using EnrollmentSystem.Web.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnrollmentSystem.Web.MVC.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        public ViewModelToDomainMappingProfile()
        {
            #region AccountModel

            CreateMap<LoginFormViewModel, AccountModel>()
                    .ForMember(g => g.EmailAddress, map => map.MapFrom(vm => vm.EmailAddress))
                    .ForMember(g => g.Password, map => map.MapFrom(vm => vm.Password));

            CreateMap<RegisterFormViewModel, AccountModel>()
                    .ForPath(g => g.AccountInformation.FirstName, map => map.MapFrom(vm => vm.FirstName))
                    .ForPath(g => g.AccountInformation.LastName, map => map.MapFrom(vm => vm.LastName))
                    .ForMember(g => g.EmailAddress, map => map.MapFrom(vm => vm.EmailAddress))
                    .ForPath(g => g.AccountInformation.Gender, map => map.MapFrom(vm => vm.Gender))
                    .ForMember(g => g.AccountType, map => map.MapFrom(vm => vm.AccountType))
                    .AfterMap<AccountModelAction>();

            CreateMap<EditAccountFormViewModel, AccountModel>()
                    .ForPath(g => g.AccountInformation.FirstName, map => map.MapFrom(vm => vm.FirstName))
                    .ForPath(g => g.AccountInformation.LastName, map => map.MapFrom(vm => vm.LastName))
                    .ForMember(g => g.EmailAddress, map => map.MapFrom(vm => vm.EmailAddress))
                    .ForPath(g => g.AccountInformation.BirthDate, map => map.MapFrom(vm => vm.BirthDate))
                    .ForPath(g => g.AccountInformation.Gender, map => map.MapFrom(vm => vm.Gender))
                    .ForMember(g => g.AccountType, map => map.MapFrom(vm => vm.AccountType))
                    .AfterMap<AccountModelAction>();

            CreateMap<CreateAccountFormViewModel, AccountModel>()
                    .ForPath(g => g.AccountInformation.FirstName, map => map.MapFrom(vm => vm.FirstName))
                    .ForPath(g => g.AccountInformation.LastName, map => map.MapFrom(vm => vm.LastName))
                    .ForMember(g => g.EmailAddress, map => map.MapFrom(vm => vm.EmailAddress))
                    .ForPath(g => g.AccountInformation.Gender, map => map.MapFrom(vm => vm.Gender))
                    .ForMember(g => g.AccountType, map => map.MapFrom(vm => vm.AccountType));

            #endregion

            #region SubjectModel

            CreateMap<CreateSubjectFormViewModel, SubjectModel>()
                    .ForMember(g => g.Code, map => map.MapFrom(vm => vm.Code))
                    .ForMember(g => g.Title, map => map.MapFrom(vm => vm.Title))
                    .ForMember(g => g.Description, map => map.MapFrom(vm => vm.Description))
                    .ForMember(g => g.Unit, map => map.MapFrom(vm => vm.Unit));

            #endregion
        }
    }
}