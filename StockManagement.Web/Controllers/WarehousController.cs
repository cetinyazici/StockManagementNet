using Microsoft.AspNetCore.Mvc;
using StockManagement.Business.Abstract;

namespace StockManagement.Web.Controllers
{
    public class WarehousController : Controller
    {
        private readonly IWarehouseService _warehouseService;

        public WarehousController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        public IActionResult Index()
        {
            var warehouses = _warehouseService.TGetAll();
            return View(warehouses);
        }
    }
}
