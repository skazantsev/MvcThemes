namespace MvcThemes.Business.Services
{
    public interface IProfileService
    {
        Profile Get();

        void SetTheme(string theme);
    }
}
