using Microsoft.AspNetCore.Mvc;

namespace VivesBlog.Controllers
{
    public class ArticlesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
