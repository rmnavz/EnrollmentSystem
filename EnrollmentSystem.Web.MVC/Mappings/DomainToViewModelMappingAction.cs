using AutoMapper;
using EnrollmentSystem.Common.Code.Conversion;
using EnrollmentSystem.Model;
using EnrollmentSystem.Web.MVC.ViewModels;

namespace EnrollmentSystem.Web.MVC.Mappings
{
    public class AccountViewModelAction : IMappingAction<AccountModel, AccountViewModel>
    {
        public void Process(AccountModel Model, AccountViewModel ViewModel)
        {
            ViewModel.ProfileImage = new Conversion().ByteArrayToImage(Model.AccountInformation.ProfileImage);
        }
    }
}