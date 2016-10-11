using System.Web;
using System.Web.Optimization;

namespace MonitoringTool
{
   public class BundleConfig
   {
      // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
      public static void RegisterBundles(BundleCollection bundles)
      {
         bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                     "~/Scripts/jquery-{version}.js",
                     "~/Scripts/jquery.maskedinput.min.js",
                     "~/Libs/jquery-ui/jquery-ui.js"));

         bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                     "~/Scripts/jquery.validate*"));

         bundles.Add(new ScriptBundle("~/bundles/chart")
            .Include("~/Scripts/Chart.min.js",
                     "~/Chart/CategoryChart.js",
                     "~/Chart/ChartRenderer.js"));

         bundles.Add(new ScriptBundle("~/bundles/sideBar")
            .Include("~/Scripts/SideBar.js"));

         bundles.Add(new ScriptBundle("~/bundles/jsTree")
            .Include("~/Libs/jsTree/jstree.min.js",
                     "~/Category/GroupTree.js"));

         bundles.Add(new ScriptBundle("~/bundles/tabs")
            .Include("~/Category/Tabs.js"));

         bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                     "~/Scripts/modernizr-*"));

         bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                   "~/Scripts/bootstrap.js",
                   "~/Scripts/respond.js",
                   "~/Scripts/bootstrap-notify.js"));

         bundles.Add(new StyleBundle("~/Content/css").Include(
                   "~/Content/bootstrap.css",
                   "~/Content/site.css",
                   "~/Content/font-awesome.min.css",
                   "~/Content/simple-sidebar.css",
                   "~/Libs/jquery-ui/jquery-ui.css").Include(
                   "~/Libs/jsTree/themes/style.css", new CssRewriteUrlTransform()));
      }
   }
}
