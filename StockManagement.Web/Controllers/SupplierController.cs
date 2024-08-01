using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Business.Abstract;
using StockManagement.Entities.Concrete;
using System.Timers;

namespace StockManagement.Web.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly IAuditService _auditService;

        public bool ModalState { get; private set; }

        public SupplierController(ISupplierService supplierService, IAuditService auditService)
        {
            _supplierService = supplierService;
            _auditService = auditService;
        }

        public IActionResult Index()
        {
            var suppliers = _supplierService.TGetAll();
            return View(suppliers);
        }

        [HttpGet]
        public IActionResult AddSupplier()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSupplier(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _supplierService.TCreate(supplier);
                _auditService.CreateAuditLog(User.Identity.Name, "Create", $"Create Supplier: {supplier.Name}, ID: {supplier.Id}");
                return RedirectToAction("Index");
            }
            else
            {
                return View(supplier);
            }
        }

        [HttpGet]
        public IActionResult UpdateSupplier(int id)
        {
            var value = _supplierService.TGetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return View(value);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateSupplier(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _supplierService.TUpdate(supplier);
                _auditService.CreateAuditLog(User.Identity.Name, "Update", $"Updated Supplier: {supplier.Name}, ID: {supplier.Id}");
                return RedirectToAction("Index");
            }
            else
            {
                return View(supplier);
            }
        }

        public IActionResult DeleteSupplier(int id)
        {
            var value = _supplierService.TGetById(id);
            if (value is not null)
            {
                _supplierService.TDelete(value);
                _auditService.CreateAuditLog(User.Identity.Name, "Delete", $"Deleted Supplier: {value.Name}, ID: {value.Id}")
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
