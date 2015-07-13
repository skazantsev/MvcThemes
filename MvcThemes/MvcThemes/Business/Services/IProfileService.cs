using MvcThemes.Theming;

namespace MvcThemes.Business.Services
{
    public interface IProfileService
    {
        Profile Get();

        void SetTheme(Theme theme);
    }
}
