using System;

namespace MvcThemes.Theming.Services
{
    public abstract class ThemeManagerBase : IThemeManager
    {
        protected ThemeManagerBase(string defaultTheme)
        {
            DefaultTheme = defaultTheme;
        }

        public string DefaultTheme { get; protected set; }

        public virtual bool IsDefaultTheme
        {
            get
            {
                return string.Equals(GetCurrentTheme(), ServiceRegistry.ThemeManager.DefaultTheme,
                    StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public abstract string GetCurrentTheme();

        public abstract void SetCurrentTheme(string theme);
    }
}