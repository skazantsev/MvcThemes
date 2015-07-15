using MvcThemes.Business.Services;

namespace MvcThemes.Theming.Services
{
    public class ProfileThemeManager : ThemeManagerBase
    {
        private readonly IProfileService _profileService;

        public ProfileThemeManager(string defaultTheme, IProfileService profileService)
            : base(defaultTheme)
        {
            _profileService = profileService;
        }

        public override string GetCurrentTheme()
        {
            var profile = _profileService.Get();
            return profile.Theme ?? DefaultTheme;
        }

        public override void SetCurrentTheme(string theme)
        {
            _profileService.SetTheme(theme);
        }
    }
}