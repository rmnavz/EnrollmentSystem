using AutoMapper;
using EnrollmentSystem.Common.Code.Conversion;
using EnrollmentSystem.Common.Code.Security;
using EnrollmentSystem.Model;
using EnrollmentSystem.Web.MVC.ViewModels;

namespace EnrollmentSystem.Web.MVC.Mappings
{
    public class AccountModelAction : 
        IMappingAction<RegisterFormViewModel, AccountModel>, 
        IMappingAction<EditAccountFormViewModel, AccountModel>
    {
        public void Process(RegisterFormViewModel ViewModel, AccountModel Model)
        {
            Model.Salt = PasswordHasher.GenerateSalt();
            Model.Password = PasswordHasher.ComputeHash(ViewModel.Password, Model.Salt);
        }

        public void Process(EditAccountFormViewModel ViewModel, AccountModel Model)
        {
            if(ViewModel.ProfileImage != null)
            {
                Model.AccountInformation.ProfileImage = new Conversion().ImageToByteArray(new Conversion().HttpPostedFileBaseToImage(ViewModel.ProfileImage));
            }
        }
    }
}