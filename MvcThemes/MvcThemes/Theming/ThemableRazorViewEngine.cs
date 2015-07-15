using MvcThemes.Theming.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MvcThemes.Theming
{
    public class ThemableRazorViewEngine : IViewEngine
    {
        private readonly object _syncObj = new object();

        private readonly IThemeManager _themeManager;

        private RazorViewEngine _lastThemableEngine;

        private string _lastTheme;

        public ThemableRazorViewEngine(IThemeManager themeManager)
        {
            _themeManager = themeManager;
        }

        // TODO: cache it!
        private RazorViewEngine GetEngine()
        {
            lock (_syncObj)
            {
                var currentTheme = _themeManager.GetCurrentTheme();
                if (_lastThemableEngine != null &&
                    string.Equals(currentTheme, _lastTheme, StringComparison.InvariantCultureIgnoreCase))
                {
                    return _lastThemableEngine;
                }

                _lastThemableEngine = new RazorViewEngine();
                _lastTheme = currentTheme;

                FillMasterLocationFormats(_lastThemableEngine, currentTheme, _themeManager.DefaultTheme);
                FillViewLocationFormats(_lastThemableEngine, currentTheme, _themeManager.DefaultTheme);
                FillPartialViewLocationFormats(_lastThemableEngine, currentTheme, _themeManager.DefaultTheme);
                return _lastThemableEngine;
            }
        }

        #region Fill location formats helpers

        private void FillMasterLocationFormats(RazorViewEngine engine, string currentTheme, string defaultTheme)
        {
            var themeLocationFormats = string.Equals(currentTheme, defaultTheme, StringComparison.InvariantCultureIgnoreCase)
                ? new string[0]
                : new[]
                {
                    "~/Themes/" + defaultTheme + "/Views/{1}/{0}.cshtml",
                    "~/Themes/" + defaultTheme + "/Views/Shared/{0}.cshtml",
                    "~/Themes/" + defaultTheme + "/Views/Shared/{1}/{0}.cshtml"
                };

            engine.MasterLocationFormats = new[]
            {
                "~/Themes/" + currentTheme + "/Views/{1}/{0}.cshtml",
                "~/Themes/" + currentTheme + "/Views/Shared/{0}.cshtml",
                "~/Themes/" + currentTheme + "/Views/Shared/{1}/{0}.cshtml"
            }.Union(themeLocationFormats)
                .Union(_lastThemableEngine.MasterLocationFormats)
                .ToArray();
        }

        private void FillViewLocationFormats(RazorViewEngine engine, string currentTheme, string defaultTheme)
        {
            var themeLocationFormats = string.Equals(currentTheme, defaultTheme, StringComparison.InvariantCultureIgnoreCase)
                ? new string[0]
                : new[]
                {
                    "~/Themes/" + defaultTheme + "/Views/{1}/{0}.cshtml"
                };

            engine.ViewLocationFormats = new[]
                {
                    "~/Themes/" + currentTheme + "/Views/{1}/{0}.cshtml"
                }.Union(themeLocationFormats)
                    .Union(_lastThemableEngine.ViewLocationFormats)
                    .ToArray();
        }

        private void FillPartialViewLocationFormats(RazorViewEngine engine, string currentTheme, string defaultTheme)
        {
            var themeLocationFormats = string.Equals(currentTheme, defaultTheme, StringComparison.InvariantCultureIgnoreCase)
                ? new string[0]
                : new[]
                {
                    "~/Themes/" + defaultTheme + "/Views/{1}/{0}.cshtml",
                    "~/Themes/" + defaultTheme + "/Views/Shared/{0}.cshtml",
                    "~/Themes/" + defaultTheme + "/Views/Shared/{1}/{0}.cshtml"
                };

            engine.PartialViewLocationFormats = new[]
                {
                    "~/Themes/" + currentTheme + "/Views/{1}/{0}.cshtml",
                    "~/Themes/" + currentTheme + "/Views/Shared/{0}.cshtml",
                    "~/Themes/" + currentTheme + "/Views/Shared/{1}/{0}.cshtml"
                }.Union(themeLocationFormats)
                .Union(_lastThemableEngine.PartialViewLocationFormats)
                .ToArray();
        }

        #endregion

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
    }
}