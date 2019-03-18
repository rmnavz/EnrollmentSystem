using System.Web.Mvc;

namespace EnrollmentSystem.Web.MVC.Controllers
{
    [Authorize]
    public class LogoutController : ControllerBase
    {
        // GET: Logout
        public ActionResult Index()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index","Home");
        }
    }
}