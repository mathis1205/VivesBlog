using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VivesBlog.Ui.Mvc.Core;
using VivesBlog.Ui.Mvc.Models;

namespace VivesBlog.Ui.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly VivesBlogDbContext _vivesBlogDbContext;

        public HomeController(VivesBlogDbContext vivesBlogDbContext)
        {
            _vivesBlogDbContext = vivesBlogDbContext;
        }

        public IActionResult Index()
        {
            var articles = _vivesBlogDbContext.Articles.ToList();
            return View(articles);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
