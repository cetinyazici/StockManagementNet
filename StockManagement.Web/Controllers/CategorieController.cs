using Microsoft.AspNetCore.Mvc;
using StockManagement.Business.Abstract;

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
    }
}
