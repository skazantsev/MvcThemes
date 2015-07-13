using System;
using MvcThemes.Business.Services;

namespace MvcThemes.Theming.Services
{
    public class ProfileThemeManager : IThemeManager
    {
        private readonly IProfileService _profileService;

        public ProfileThemeManager(IProfileService profileService)
        {
            _profileService = profileService;
        }

        public string GetCurrentTheme()
        {
            var profile = _profileService.Get();
            return profile.Theme.ToString();
        }

        public void SetCurrentTheme(string theme)
        {
            _profileService.SetTheme((Theme)Enum.Parse(typeof(Theme), theme));
        }
    }
}