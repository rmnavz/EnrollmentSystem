using AutoMapper;
using EnrollmentSystem.Model;
using EnrollmentSystem.Service;
using EnrollmentSystem.Web.MVC.Common.Filters;
using EnrollmentSystem.Web.MVC.ViewModels;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Web.Mvc;

namespace EnrollmentSystem.Web.MVC.Controllers
{
    [GuestOnly]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {

        public LoginController(IAccountService AccountService)
        {
            _AccountService = AccountService;
        }

        // GET: Login
        public ActionResult Index() => View();

        [HttpPost]
        public ActionResult Login(LoginFormViewModel Model)
        {
            if (!ModelState.IsValid) { return View("Index", Model); }

            AccountModel Account = _AccountService.Login(Model.EmailAddress, Model.Password);

            if (Account != null)
            {
                ClaimsIdentity identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);

                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, Account.ID.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Email, Account.EmailAddress));
                identity.AddClaim(new Claim(ClaimTypes.Role, Account.AccountType.ToString()));

                identity.AddClaim(new Claim(ClaimTypes.Name, Account.AccountInformation.FirstName + " " + Account.AccountInformation.LastName));

                AuthenticationManager.SignIn(identity);

                return RedirectToAction("Index", "Home");
            }

            return View("Index", Model);
        }

        
    }
}