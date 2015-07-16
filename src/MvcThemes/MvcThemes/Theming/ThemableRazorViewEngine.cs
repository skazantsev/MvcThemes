using MvcThemes.Theming.Services;
using System.Collections.Concurrent;
using System.Linq;
using System.Web.Mvc;

namespace MvcThemes.Theming
{
    public class ThemableRazorViewEngine : IViewEngine
    {
        private readonly IThemeManager _themeManager;

        private readonly ConcurrentDictionary<string, RazorViewEngine> _themeEngines; 

        public ThemableRazorViewEngine(IThemeManager themeManager)
        {
            _themeManager = themeManager;
            _themeEngines = new ConcurrentDictionary<string, RazorViewEngine>();
        }

        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            var result = GetEngine().FindPartialView(controllerContext, partialViewName, useCache);
            return result;
        }

        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            var result = GetEngine().FindView(controllerContext, viewName, masterName, useCache);
            return result;
        }

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {
            GetEngine().ReleaseView(controllerContext, view);
        }

        private RazorViewEngine GetEngine()
        {
            var currentTheme = _themeManager.GetCurrentTheme();
            var viewEngine = _themeEngines.GetOrAdd(currentTheme, _ =>
            {
                var engine = new RazorViewEngine();
                FillMasterLocationFormats(engine, _themeManager);
                FillViewLocationFormats(engine, _themeManager);
                FillPartialViewLocationFormats(engine, _themeManager);
                return engine;
            });
            return viewEngine;
        }

        private void FillMasterLocationFormats(RazorViewEngine engine, IThemeManager themeManager)
        {
            var currentTheme = _themeManager.GetCurrentTheme();
            var themeLocationFormats = themeManager.IsDefaultTheme
                ? new string[0]
                : new[]
                {
                    "~/Themes/" + themeManager.DefaultTheme + "/Views/{1}/{0}.cshtml",
                    "~/Themes/" + themeManager.DefaultTheme + "/Views/Shared/{0}.cshtml",
                    "~/Themes/" + themeManager.DefaultTheme + "/Views/Shared/{1}/{0}.cshtml"
                };

            engine.MasterLocationFormats = new[]
            {
                "~/Themes/" + currentTheme + "/Views/{1}/{0}.cshtml",
                "~/Themes/" + currentTheme + "/Views/Shared/{0}.cshtml",
                "~/Themes/" + currentTheme + "/Views/Shared/{1}/{0}.cshtml"
            }.Union(themeLocationFormats)
                .Union(engine.MasterLocationFormats)
                .ToArray();
        }

        private void FillViewLocationFormats(RazorViewEngine engine, IThemeManager themeManager)
        {
            var currentTheme = _themeManager.GetCurrentTheme();
            var themeLocationFormats = themeManager.IsDefaultTheme
                ? new string[0]
                : new[]
                {
                    "~/Themes/" + themeManager.DefaultTheme + "/Views/{1}/{0}.cshtml"
                };

            engine.ViewLocationFormats = new[]
                {
                    "~/Themes/" + currentTheme + "/Views/{1}/{0}.cshtml"
                }.Union(themeLocationFormats)
                    .Union(engine.ViewLocationFormats)
                    .ToArray();
        }

        private void FillPartialViewLocationFormats(RazorViewEngine engine, IThemeManager themeManager)
        {
            var currentTheme = _themeManager.GetCurrentTheme();
            var themeLocationFormats = themeManager.IsDefaultTheme
                ? new string[0]
                : new[]
                {
                    "~/Themes/" + themeManager.DefaultTheme + "/Views/{1}/{0}.cshtml",
                    "~/Themes/" + themeManager.DefaultTheme + "/Views/Shared/{0}.cshtml",
                    "~/Themes/" + themeManager.DefaultTheme + "/Views/Shared/{1}/{0}.cshtml"
                };

            engine.PartialViewLocationFormats = new[]
                {
                    "~/Themes/" + currentTheme + "/Views/{1}/{0}.cshtml",
                    "~/Themes/" + currentTheme + "/Views/Shared/{0}.cshtml",
                    "~/Themes/" + currentTheme + "/Views/Shared/{1}/{0}.cshtml"
                }.Union(themeLocationFormats)
                .Union(engine.PartialViewLocationFormats)
                .ToArray();
        }
    }
}