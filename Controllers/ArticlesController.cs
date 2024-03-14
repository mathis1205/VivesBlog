using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            _vivesBlogDbContext.Articles.Add(article);
            _vivesBlogDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var article = _vivesBlogDbContext.Articles.FirstOrDefault(p => p.Id == id);
            if (article == null) return RedirectToAction("Index");
            return View(article);
        }
        [HttpPost]
        public IActionResult Edit(Article article)
        {
            if (string.IsNullOrWhiteSpace(article.Title) || string.IsNullOrWhiteSpace(article.Author)) return RedirectToAction("Index");
            _vivesBlogDbContext.Articles.Update(article);
            _vivesBlogDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            var person = _vivesBlogDbContext.Articles
                .FirstOrDefault(p => p.Id == id);

            return View(person);
        }

        [HttpPost("/[controller]/Delete/{id:int?}"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var person = _vivesBlogDbContext.Articles
                .FirstOrDefault(p => p.Id == id);

            if (person is null)
            {
                return RedirectToAction("Index");
            }

            _vivesBlogDbContext.Articles.Remove(person);
            _vivesBlogDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
