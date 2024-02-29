using Microsoft.AspNetCore.Mvc;
using VivesBlog.Ui.Mvc.Core;
using VivesBlog.Ui.Mvc.Models;

namespace VivesBlog.Ui.Mvc.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly VivesBlogDbContext _vivesBlogDbContext;

        public ArticlesController(VivesBlogDbContext vivesBlogDbContext)
        {
            _vivesBlogDbContext = vivesBlogDbContext;
        }
        public IActionResult Index()
        {
            var articles = _vivesBlogDbContext.Articles.ToList();
            return View(articles);
        }

    }
}
