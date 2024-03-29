﻿using AutoMapper;
using EnrollmentSystem.Model;
using EnrollmentSystem.ViewModels;

namespace EnrollmentSystem.Mapping.Profiles
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
                    .ForMember(g => g.AccountType, map => map.MapFrom(vm => vm.AccountType));

            CreateMap<EditAccountFormViewModel, AccountModel>()
                    .ForMember(g => g.ID, map => map.MapFrom(vm => vm.ID))
                    .ForPath(g => g.AccountInformation.FirstName, map => map.MapFrom(vm => vm.FirstName))
                    .ForPath(g => g.AccountInformation.LastName, map => map.MapFrom(vm => vm.LastName))
                    .ForMember(g => g.EmailAddress, map => map.MapFrom(vm => vm.EmailAddress))
                    .ForPath(g => g.AccountInformation.BirthDate, map => map.MapFrom(vm => vm.BirthDate))
                    .ForPath(g => g.AccountInformation.Gender, map => map.MapFrom(vm => vm.Gender))
                    .ForMember(g => g.AccountType, map => map.MapFrom(vm => vm.AccountType));

            CreateMap<CreateAccountFormViewModel, AccountModel>()
                    .ForPath(g => g.AccountInformation.FirstName, map => map.MapFrom(vm => vm.FirstName))
                    .ForPath(g => g.AccountInformation.LastName, map => map.MapFrom(vm => vm.LastName))
                    .ForMember(g => g.EmailAddress, map => map.MapFrom(vm => vm.EmailAddress))
                    .ForPath(g => g.AccountInformation.Gender, map => map.MapFrom(vm => vm.Gender))
                    .ForMember(g => g.AccountType, map => map.MapFrom(vm => vm.AccountType));

            #endregion

            #region SubjectModel

            CreateMap<CreateSubjectFormViewModel, SubjectModel>()
                    .ForMember(g => g.Code, map => map.MapFrom(vm => vm.Code.ToUpper()))
                    .ForMember(g => g.Title, map => map.MapFrom(vm => vm.Title))
                    .ForMember(g => g.Description, map => map.MapFrom(vm => vm.Description))
                    .ForMember(g => g.Unit, map => map.MapFrom(vm => vm.Unit))
                    .ForMember(g => g.Lecture, map => map.MapFrom(vm => vm.Lecture))
                    .ForMember(g => g.Laboratory, map => map.MapFrom(vm => vm.Laboratory));

            CreateMap<EditSubjectFormViewModel, SubjectModel>()
                    .ForMember(g => g.Code, map => map.MapFrom(vm => vm.Code.ToUpper()))
                    .ForMember(g => g.Title, map => map.MapFrom(vm => vm.Title))
                    .ForMember(g => g.Description, map => map.MapFrom(vm => vm.Description))
                    .ForMember(g => g.Unit, map => map.MapFrom(vm => vm.Unit))
                    .ForMember(g => g.Lecture, map => map.MapFrom(vm => vm.Lecture))
                    .ForMember(g => g.Laboratory, map => map.MapFrom(vm => vm.Laboratory));

            #endregion

            #region SubjectModel

            CreateMap<CreateDepartmentFormViewModel, DepartmentModel>()
                    .ForMember(g => g.Code, map => map.MapFrom(vm => vm.Code.ToUpper()))
                    .ForMember(g => g.Title, map => map.MapFrom(vm => vm.Title))
                    .ForMember(g => g.Description, map => map.MapFrom(vm => vm.Description));

            CreateMap<EditDepartmentFormViewModel, DepartmentModel>()
                    .ForMember(g => g.Code, map => map.MapFrom(vm => vm.Code.ToUpper()))
                    .ForMember(g => g.Title, map => map.MapFrom(vm => vm.Title))
                    .ForMember(g => g.Description, map => map.MapFrom(vm => vm.Description));

            CreateMap<EditDepartmentAccountFormViewModel, DepartmentModel>()
                    .ForMember(g => g.Code, map => map.MapFrom(vm => vm.Code.ToUpper()))
                    .ForMember(g => g.Title, map => map.MapFrom(vm => vm.Title))
                    .ForMember(g => g.Description, map => map.MapFrom(vm => vm.Description));

            #endregion
        }
    }
}
