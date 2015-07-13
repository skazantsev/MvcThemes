namespace MvcThemes.Theming.Services
{
    public interface IThemeManager
    {
        string GetCurrentTheme();

        void SetCurrentTheme(string theme);
    }
}