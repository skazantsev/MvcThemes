using MvcThemes.Theming;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcThemes
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterViewEngines();
        }

        private void RegisterViewEngines()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new ThemableRazorViewEngine(ServiceRegistry.ThemeManager));
        }
    }
}
