namespace MvcThemes.Theming.Services
{
    public abstract class ThemeManagerBase : IThemeManager
    {
        protected ThemeManagerBase(string defaultTheme)
        {
            DefaultTheme = defaultTheme;
        }

        public string DefaultTheme { get; protected set; }

        public abstract string GetCurrentTheme();

        public abstract void SetCurrentTheme(string theme);
    }
}