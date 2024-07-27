using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StockManagement.Business.Abstract;
using StockManagement.Entities.Concrete;

namespace StockManagement.Web.Controllers
{
    public class CategorieController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategorieController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categoryies = _categoryService.TGetAll();
            return View(categoryies);
        }

        [HttpGet]
        public IActionResult AddCategorie()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategorie(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.TCreate(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        [HttpGet]
        public IActionResult UpdateCategorie(int id)
        {
            var categorie = _categoryService.TGetById(id);
            if (categorie == null)
            {
                return NotFound();
            }
            return View(categorie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCategorie(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.TUpdate(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult DeleteCategorie(int id)
        {
            var values = _categoryService.TGetById(id);
            if(values is not null)
            {
                _categoryService.TDelete(values);
                return RedirectToAction("Index");
            }
            return View(values);
        }
    }
}
