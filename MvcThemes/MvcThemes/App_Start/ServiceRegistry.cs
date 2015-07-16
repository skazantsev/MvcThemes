using MvcThemes.Business.Services;
using MvcThemes.Theming;
using MvcThemes.Theming.Services;

namespace MvcThemes
{
    // let's not complicate this example with DI
    public static class ServiceRegistry
    {
        public static readonly IThemeManager ThemeManager =
            new ProfileThemeManager(Theme.Default.ToString(), new InMemoryProfileService());
    }
}