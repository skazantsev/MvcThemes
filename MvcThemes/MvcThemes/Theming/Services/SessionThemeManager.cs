using System;
using System.Web;

namespace MvcThemes.Theming.Services
{
    public class SessionThemeManager : IThemeManager
    {
        protected string ThemeKey = "Theme";

        public string GetCurrentTheme()
        {
            AssertSession();
            if (HttpContext.Current.Session[ThemeKey] == null)
                return string.Empty;

            return HttpContext.Current.Session[ThemeKey].ToString();
        }

        public void SetCurrentTheme(string theme)
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