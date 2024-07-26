using Microsoft.AspNetCore.Mvc;
using StockManagement.Business.Abstract;

namespace StockManagement.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.TGetAll();
            return View(products);
        }
    }
}
