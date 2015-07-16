using MvcThemes.Theming;
using System;

namespace MvcThemes.Models.Index
{
    public class IndexModel
    {
        public IndexModel(string theme)
        {
            Theme = (Theme)Enum.Parse(typeof(Theme), theme, true);
        }

        public Theme Theme { get; private set; }
    }
}