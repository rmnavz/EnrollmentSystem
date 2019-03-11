using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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