using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Business.Abstract;

namespace StockManagement.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IProductService _productService;

        public DashboardController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            int threshold = 10;
            var lowStockProductNames = await _productService.GetLowStockProductNamesAsync(threshold);

            if (lowStockProductNames.Any())
            {
                ViewBag.NotificationMessage = "Stoktaki ürünlerin sayısı 10'a düştü: " +
                                              string.Join(", ", lowStockProductNames);
            }
            else
            {
                ViewBag.NotificationMessage = string.Empty;
            }

            return View();
        }
    }
}
