using MvcThemes.Theming;

namespace MvcThemes.Business
{
    public class Profile
    {
        public Profile()
        {
            Theme = Theme.Default;
        }

        public Theme Theme { get; set; }
    }
}