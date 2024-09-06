using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StockManagement.Business.Abstract;
using StockManagement.Entities.Concrete;

namespace StockManagement.Web.Controllers
{
    [Authorize]
    public class CategorieController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IAuditService _auditService;

        public CategorieController(
                        ICategoryService categoryService,
                        IAuditService auditService)
        {
            _categoryService = categoryService;
            _auditService = auditService;
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
                _auditService.CreateAuditLog(User.Identity.Name, "Create", $"Categorie Created: {category.CategoryName}, ID: {category.Id}");
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
                _auditService.CreateAuditLog(User.Identity.Name, "Update", $"Categorie Updated: {category.CategoryName}, ID: {category.Id}");
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult DeleteCategorie(int id)
        {
            var values = _categoryService.TGetById(id);
            if (values is not null)
            {
                _categoryService.TDelete(values);
                _auditService.CreateAuditLog(User.Identity.Name, "Delete", $"Categorie Deleted: {values.CategoryName}, ID: {values.Id}");

                return RedirectToAction("Index");
            }
            return View(values);
        }
    }
}
