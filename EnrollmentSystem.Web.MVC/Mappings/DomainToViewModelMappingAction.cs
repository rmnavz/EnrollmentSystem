using AutoMapper;
using EnrollmentSystem.Common.Code.Conversion;
using EnrollmentSystem.Model;
using EnrollmentSystem.Web.MVC.ViewModels;
using System;

namespace EnrollmentSystem.Web.MVC.Mappings
{
    public class AccountViewModelAction : IMappingAction<AccountModel, AccountViewModel>
    {
        public void Process(AccountModel Model, AccountViewModel ViewModel)
        {
            //ViewModel.ProfileImage = new Conversion().ByteArrayToImage(Model.AccountInformation.ProfileImage);
            ViewModel.ProfileImage = string.Format("data:image/jpeg;base64,{0}", Convert.ToBase64String(Model.AccountInformation.ProfileImage));
        }
    }
}