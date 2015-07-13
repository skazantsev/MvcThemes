using MvcThemes.Business.Services;
using MvcThemes.MvcExtensions;
using MvcThemes.Theming.Services;
using System.Web.Mvc;

namespace MvcThemes.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IThemeManager ThemeManager;

        public BaseController()
        {
            ThemeManager = new ProfileThemeManager(new InMemoryProfileService());
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewData[ViewDataKeys.CurrentTheme] = ThemeManager.GetCurrentTheme();
        }
    }
}