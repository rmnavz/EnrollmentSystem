using EnrollmentSystem.Web.MVC.Common.Filters;
using System.Web;
using System.Web.Mvc;

namespace EnrollmentSystem.Web.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
