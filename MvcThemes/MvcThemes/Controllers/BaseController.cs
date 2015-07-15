using MvcThemes.Business.Services;
using MvcThemes.MvcExtensions;
using MvcThemes.Theming;
using MvcThemes.Theming.Services;
using System.Web.Mvc;

namespace MvcThemes.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IThemeManager ThemeManager;

        public BaseController()
        {
            ThemeManager = new ProfileThemeManager(Theme.Default.ToString(), new InMemoryProfileService());
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewData[ViewDataKeys.CurrentTheme] = ThemeManager.GetCurrentTheme();
        }
    }
}