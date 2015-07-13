using MvcThemes.Theming;

namespace MvcThemes.Business.Services
{
    public class InMemoryProfileService : IProfileService
    {
        private static readonly Profile Profile = new Profile();

        public Profile Get()
        {
            return Profile;
        }

        public void SetTheme(Theme theme)
        {
            Profile.Theme = theme;
        }
    }
}