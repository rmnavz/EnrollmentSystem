using AutoMapper;
using EnrollmentSystem.Model;
using EnrollmentSystem.Service;
using EnrollmentSystem.Web.MVC.ViewModels;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace EnrollmentSystem.Web.MVC.Controllers
{
    public class ControllerBase : Controller
    {
        protected IAccountService _AccountService;

        public ControllerBase()
        {
            ViewBag.ApplicationName = "Enrollment System";
        }

        protected IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        protected int GetUserID()
        {
            var ClaimsIdentity = User.Identity as ClaimsIdentity;
            string ID = ClaimsIdentity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            return int.Parse(ID.ToString());
        }

        protected bool IsEmailExist(string EmailAddress) => _AccountService.IsEmailExist(EmailAddress);

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var Model = filterContext.ActionParameters.SingleOrDefault(ap => ap.Key.ToLower() == "model").Value;
            base.OnActionExecuting(filterContext);
        }
    }
}