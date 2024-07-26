using Microsoft.AspNetCore.Mvc;
using StockManagement.Business.Abstract;

namespace StockManagement.Web.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public IActionResult Index()
        {
            var suppliers = _supplierService.TGetAll();
            return View(suppliers);
        }
    }
}
