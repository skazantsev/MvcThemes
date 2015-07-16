using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace MvcThemes.MvcExtensions
{
    public static class HtmlExtentions
    {
        public static MvcHtmlString ThemableImage(this HtmlHelper html, string contentPath, object htmlAttributes)
        {
            return ThemableImage(html, contentPath, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString ThemableImage(this HtmlHelper html, string contentPath, IDictionary<string, object> htmlAttributes)
        {
            var contentUrl = UrlHelper.GenerateContentUrl(
                GetThemableImagePath(html, contentPath),
                html.ViewContext.HttpContext);

            var tag = new TagBuilder("img");
            tag.MergeAttribute("src", contentUrl);
            tag.MergeAttributes(htmlAttributes);
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.SelfClosing));
        }

        private static string GetThemableImagePath(HtmlHelper html, string contentPath)
        {
            var themeManager = ServiceRegistry.ThemeManager;
            if (themeManager.IsDefaultTheme)
                return contentPath;

            var themablePath = Path.ChangeExtension(contentPath, themeManager.GetCurrentTheme() + Path.GetExtension(contentPath));
            var physicalPath = html.ViewContext.HttpContext.Server.MapPath(themablePath);
            return File.Exists(physicalPath) ? themablePath : contentPath;
        }
    }
}