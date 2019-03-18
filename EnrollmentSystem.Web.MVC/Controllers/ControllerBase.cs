using EnrollmentSystem.Service;
using EnrollmentSystem.Web.MVC.Common.PartialModels;
using Microsoft.Owin.Security;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace EnrollmentSystem.Web.MVC.Controllers
{
    public class ControllerBase : ControllerExtension
    {
        protected string _SearchQuery = null;
        protected DynamicModalOptions _DynamicModalOptions = new DynamicModalOptions();
        protected IAccountService _AccountService;
        protected ISubjectService _SubjectService;
        protected IDepartmentService _DepartmentService;

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

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool isFullscreen = (Session["isFullscreen"] != null) ? (bool)Session["isFullscreen"] : false;
            Session["isFullscreen"] = isFullscreen;
            if (isFullscreen)
            {
                ViewBag.toolbarClass = "fullscreen";
                ViewBag.maximizeClass = "d-none";
                ViewBag.minimizeClass = "";
            }
            else
            {
                ViewBag.toolbarClass = "";
                ViewBag.maximizeClass = "";
                ViewBag.minimizeClass = "d-none";
            }

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

        protected ActionResult ModalMessage(string Title, string Message) => PartialView("Partials/_MessageModal", new MessageModal()
        {
            Title = Title,
            Message = Message
        });

        public ActionResult ToggleFullscreen()
        {
            Session["isFullscreen"] = !(bool)Session["isFullscreen"];
            return Json(new { success = true });
        }
    }
}