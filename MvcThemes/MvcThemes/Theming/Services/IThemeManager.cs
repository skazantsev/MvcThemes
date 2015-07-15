namespace MvcThemes.Theming.Services
{
    public interface IThemeManager
    {
        string DefaultTheme { get; }

        string GetCurrentTheme();

        void SetCurrentTheme(string theme);
    }
}