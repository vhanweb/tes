using System.Web;
using System.Web.Optimization;

namespace POS.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.1.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminlte").Include(
                      "~/Scripts/plugins/slimscroll/jquery.slimscroll.min.js",
                      "~/Scripts/plugins/sparkline/jquery.sparkline.min.js",
                      "~/Scripts/pages/Shared/_Layout.js",
                      "~/Scripts/adminlte/app.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/font-awesome.min.css",
                      "~/Content/ionicons.min.css",
                      "~/Content/icomoon.min.css",
                      "~/Content/bootstrap.css",
                      "~/Content/admin-lte.css",
                      "~/Content/skins/_all-skins.min.css"));

            #region Plugins
            // icheck
            bundles.Add(new ScriptBundle("~/bundles/plugins/icheck").Include(
                     "~/Scripts/plugins/icheck/icheck.min.js"));

            bundles.Add(new StyleBundle("~/Content/plugins/icheck").Include(
                     "~/Content/plugins/icheck/all.css"));

            bundles.Add(new StyleBundle("~/Content/plugins/icheck/square/blue").Include(
                     "~/Content/plugins/icheck/square/blue.css"));

            bundles.Add(new StyleBundle("~/Content/plugins/icheck/flat").Include(
                     "~/Content/plugins/icheck/flat/flat.css"));

            // datepicker
            bundles.Add(new ScriptBundle("~/bundles/plugins/datepicker").Include(
                     "~/Scripts/plugins/datepicker/bootstrap-datepicker.js"));

            bundles.Add(new StyleBundle("~/Content/plugins/datepicker").Include(
                     "~/Content/plugins/datepicker/datepicker3.css"));

            // daterangepicker
            bundles.Add(new ScriptBundle("~/bundles/plugins/daterangepicker").Include(
                     "~/Scripts/plugins/daterangepicker/moment.min.js",
                     "~/Scripts/plugins/daterangepicker/daterangepicker.js"));

            bundles.Add(new StyleBundle("~/Content/plugins/daterangepicker").Include(
                     "~/Content/plugins/daterangepicker/daterangepicker-bs3.css"));

            //bootstrap-wysihtml5
            bundles.Add(new ScriptBundle("~/bundles/plugins/bootstrap-wysihtml5").Include(
                     "~/Scripts/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"));

            bundles.Add(new StyleBundle("~/Content/plugins/bootstrap-wysihtml5").Include(
                     "~/Content/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.min.css"));
            //morris
            bundles.Add(new ScriptBundle("~/bundles/plugins/morris").Include(
                     "~/Scripts/plugins/morris/morris.min.js"));

            bundles.Add(new StyleBundle("~/Content/plugins/morris").Include(
                     "~/Content/plugins/morris/morris.css"));
            //jvectormap
            bundles.Add(new ScriptBundle("~/bundles/plugins/jvectormap").Include(
                     "~/Scripts/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                     "~/Scripts/plugins/jvectormap/jquery-jvectormap-world-mill-en.js"));

            bundles.Add(new StyleBundle("~/Content/plugins/jvectormap").Include(
                     "~/Content/plugins/jvectormap/jquery-jvectormap-1.2.2.css"));

            //sparkline
            bundles.Add(new ScriptBundle("~/bundles/plugins/sparkline").Include(
                     "~/Scripts/plugins/sparkline/jquery.sparkline.min.js"));
            //knob
            bundles.Add(new ScriptBundle("~/bundles/plugins/knob").Include(
                     "~/Scripts/plugins/knob/jquery.knob.js"));
            //raphael
            bundles.Add(new ScriptBundle("~/bundles/plugins/raphael").Include(
                     "~/Scripts/plugins/raphael/raphael.min.js"));
            //jquery-ui
            bundles.Add(new ScriptBundle("~/bundles/plugins/jquery-ui").Include(
                     "~/Scripts/plugins/jquery-ui/jquery-ui.min.js"));
            //chartjs
            bundles.Add(new ScriptBundle("~/bundles/plugins/chartjs").Include(
                     "~/Scripts/plugins/chartjs/chartjs.min.js"));
            #endregion

            #region Pages
            // pages
            bundles.Add(new ScriptBundle("~/bundles/pages/Shared").Include(
                     "~/Scripts/pages/Shared/_Layout.js"));

            bundles.Add(new ScriptBundle("~/bundles/pages/Account/Login").Include(
                     "~/Scripts/pages/Account/Login.js"));

            bundles.Add(new ScriptBundle("~/bundles/pages/Account/Register").Include(
                    "~/Scripts/pages/Account/Register.js"));

            bundles.Add(new ScriptBundle("~/bundles/pages/Home/DashboardV1").Include(
                     "~/Scripts/pages/Home/DashboardV1.js"));

            bundles.Add(new ScriptBundle("~/bundles/pages/Home/DashboardV1-menu").Include(
                     "~/Scripts/pages/Home/DashboardV1-menu.js"));

            bundles.Add(new ScriptBundle("~/bundles/pages/Home/DashboardV2").Include(
                     "~/Scripts/pages/Home/DashboardV2.js"));

            bundles.Add(new ScriptBundle("~/bundles/pages/Home/DashboardV2-menu").Include(
                     "~/Scripts/pages/Home/DashboardV2-menu.js"));
            #endregion
        }
    }
}
