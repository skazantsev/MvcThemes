using System.Web.Mvc;
using MvcThemes.Models.Index;
using MvcThemes.Theming;

namespace MvcThemes.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var model = new IndexModel(ThemeManager.GetCurrentTheme());
            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeTheme(Theme theme)
        {
            ThemeManager.SetCurrentTheme(theme.ToString());
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}