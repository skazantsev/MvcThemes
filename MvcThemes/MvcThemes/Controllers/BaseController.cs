using MvcThemes.MvcExtensions;
using MvcThemes.Theming.Services;
using System.Web.Mvc;

namespace MvcThemes.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IThemeManager ThemeManager;

        public BaseController()
            : this(ServiceRegistry.ThemeManager)
        {
        }

        public BaseController(IThemeManager themeManager)
        {
            ThemeManager = themeManager;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewData[ViewDataKeys.CurrentTheme] = ServiceRegistry.ThemeManager.GetCurrentTheme();
        }
    }
}