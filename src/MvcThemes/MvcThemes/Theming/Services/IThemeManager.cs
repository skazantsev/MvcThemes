namespace MvcThemes.Theming.Services
{
    public interface IThemeManager
    {
        string DefaultTheme { get; }

        bool IsDefaultTheme { get; }

        string GetCurrentTheme();

        void SetCurrentTheme(string theme);
    }
}