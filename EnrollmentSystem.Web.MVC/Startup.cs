using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace EnrollmentSystem.Web.MVC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var authenticationOptions = new CookieAuthenticationOptions
            {
                LoginPath = new PathString("/Login/Index"),
                LogoutPath = new PathString("/Logout/Index"),
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            };

            app.UseCookieAuthentication(authenticationOptions);
        }
    }
}