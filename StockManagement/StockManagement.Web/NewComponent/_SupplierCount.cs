using Microsoft.AspNetCore.Mvc;
using StockManagement.Business.Abstract;

namespace StockManagement.Web.NewComponent
{
    public class _SupplierCount : ViewComponent
    {
        private readonly ISupplierService _supplierService;

        public _SupplierCount(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public IViewComponentResult Invoke()
        {
            var supplier = _supplierService.TGetAll();
            return View(supplier);
        }
    }
}
