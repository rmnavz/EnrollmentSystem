using System.Web;
using System.Web.Optimization;

namespace EnrollmentSystem.Web.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Libraries/jquery/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Libraries/jquery-validate/jquery.validate.js",
                        "~/Libraries/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Libraries/modernizr/modernizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Libraries/twitter-bootstrap/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/dynamicModal").Include(
                      "~/Scripts/DynamicModal.js"));

            bundles.Add(new ScriptBundle("~/bundles/PageTransition").Include(
                      "~/Scripts/PageTransition.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Libraries/twitter-bootstrap/css/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css/sidebar").Include(
                      "~/Content/sidebar.css"));

            bundles.Add(new StyleBundle("~/Content/css/splitscreen").Include(
                      "~/Content/splitscreen.css"));

        }
    }
}
