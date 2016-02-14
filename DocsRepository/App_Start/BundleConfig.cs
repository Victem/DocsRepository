using System.Web;
using System.Web.Optimization;

namespace DocsRepository
{
    public class BundleConfig
    {
        //Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui*",
                        
                        "~/Scripts/SearchScript.js",
                        "~/Scripts/tag-it.js",
                        "~/Scripts/bootstrap-datetimepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство сборки на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/Scripts/moment.js",
                       "~/Scripts/bootstrap.js",
                       "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/jquery-ui").Include(                    
                     "~/Content/themes/base/jquery-ui-1.10.4.custom.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",                     
                      "~/Content/font-awesome.css",                     
                      "~/Content/jquery.tagit.css",
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/Site.css"));

            // Присвойте EnableOptimizations значение false для отладки. Дополнительные сведения
            // см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
