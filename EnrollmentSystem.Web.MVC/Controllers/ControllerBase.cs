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
        protected string _SearchQuery = null;
        protected IAccountService _AccountService;
        protected ISubjectService _SubjectService;

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
            _SearchQuery = HttpContext.Request.QueryString.Get("Search");

            var Model = filterContext.ActionParameters.SingleOrDefault(ap => ap.Key.ToLower() == "model").Value;
            var ControllerName = filterContext.RouteData.GetRequiredString("controller");

            ViewBag.Title = string.Join(
                                string.Empty,
                                ControllerName.Select((x, i) => (
                                     char.IsUpper(x) && i > 0 &&
                                     (char.IsLower(ControllerName[i - 1]) || (i < ControllerName.Count() - 1 && char.IsLower(ControllerName[i + 1])))
                                ) ? " " + x : x.ToString()));

            ViewBag.CurrentController = ControllerName;
            ViewBag.SearchValue = _SearchQuery;

            base.OnActionExecuting(filterContext);
        }
    }
}