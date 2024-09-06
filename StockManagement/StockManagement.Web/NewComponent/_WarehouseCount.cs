using Microsoft.AspNetCore.Mvc;
using StockManagement.Business.Abstract;

namespace StockManagement.Web.NewComponent
{
    public class _WarehouseCount : ViewComponent
    {
        private readonly IWarehouseService _warehouseService;

        public _WarehouseCount(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        public IViewComponentResult Invoke()
        {
            var warehouse = _warehouseService.TGetAll();
            return View(warehouse);
        }
    }
}
