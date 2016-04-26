using System.Web;
using System.Web.Optimization;

namespace MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/spa").
                Include( "~/SPA/app.js").
                Include("~/SPA/employees/controllers/employee.controller.js").
                Include("~/SPA/employees/services/employees.service.js").
                Include("~/SPA/employees/employee.module.js")
                );
            
        }
    }
}