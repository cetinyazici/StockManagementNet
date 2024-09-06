using Microsoft.AspNetCore.Mvc;
using StockManagement.Business.Abstract;

namespace StockManagement.Web.NewComponent
{
    public class _ProductCount : ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductCount(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var product = _productService.TGetAll();
            return View(product);
        }
    }
}
