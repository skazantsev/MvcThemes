using System;
using System.Web;

namespace MvcThemes.Theming.Services
{
    public class SessionThemeManager : ThemeManagerBase
    {
        protected string ThemeKey = "Theme";

        public SessionThemeManager(string defaultTheme)
            : base(defaultTheme)
        { }

        public override string GetCurrentTheme()
        {
            AssertSession();
            return HttpContext.Current.Session[ThemeKey] != null
                ? HttpContext.Current.Session[ThemeKey].ToString()
                : DefaultTheme;
        }

        public override void SetCurrentTheme(string theme)
        {
            AssertSession();
            HttpContext.Current.Session[ThemeKey] = theme;
        }

        public void AssertSession()
        {
            if (HttpContext.Current == null)
                throw new InvalidOperationException("HttpContext can't be null");

            if (HttpContext.Current.Session == null)
                throw new InvalidOperationException("Session can't be null");
        }
    }
}