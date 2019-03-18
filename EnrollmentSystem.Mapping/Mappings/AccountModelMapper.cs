using AutoMapper;
using EnrollmentSystem.Common.Code.Conversion;
using EnrollmentSystem.Common.Code.Security;
using EnrollmentSystem.Model;
using EnrollmentSystem.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace EnrollmentSystem.Mapping.Mappings
{
    public static class AccountModelMapper
    {
        public static AccountModel ToAccountModel(this RegisterFormViewModel ViewModel)
        {
            AccountModel Model = new AccountModel();
            Model = Mapper.Map<RegisterFormViewModel, AccountModel>(ViewModel);
            Model.Salt = PasswordHasher.GenerateSalt();
            Model.Password = PasswordHasher.ComputeHash(ViewModel.Password, Model.Salt);
            return Model;
        }

        public static AccountModel ToAccountModel(this CreateAccountFormViewModel ViewModel)
        {
            AccountModel Model = new AccountModel();
            Model = Mapper.Map<CreateAccountFormViewModel, AccountModel>(ViewModel);
            return Model;
        }

        public static AccountModel ToAccountModel(this EditAccountFormViewModel ViewModel, AccountModel Bind)
        {
            AccountModel Model = Bind ?? new AccountModel();
            Mapper.Map(ViewModel, Model);
            if (ViewModel != null)
            {
                Model.AccountInformation.ProfileImage = ViewModel.ProfileImage.ToByteArray();
            }
            return Model;
        }

        public static AccountViewModel ToAccountViewModel(this AccountModel Model)
        {
            AccountViewModel ViewModel = new AccountViewModel();
            ViewModel = Mapper.Map<AccountModel, AccountViewModel>(Model);
            ViewModel.BirthDate = Model.AccountInformation.BirthDate.ToCustomDateString();
            ViewModel.ProfileImage = Model.AccountInformation.ProfileImage.ToDataString();
            return ViewModel;
        }

        public static IEnumerable<AccountViewModel> ToAccountViewModel(this IEnumerable<AccountModel> Model)
        {
            List<AccountViewModel> ViewModel = new List<AccountViewModel>();
            Model.ToList().ForEach(x => ViewModel.Add(x.ToAccountViewModel()));
            return ViewModel;
        }

        public static EditAccountFormViewModel ToEditAccountFormViewModel(this AccountModel Model)
        {
            EditAccountFormViewModel ViewModel = new EditAccountFormViewModel();
            ViewModel = Mapper.Map<AccountModel, EditAccountFormViewModel>(Model);
            return ViewModel;
        }
    }
}
