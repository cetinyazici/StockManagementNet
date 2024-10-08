﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Business.Abstract;
using StockManagement.Entities.Concrete;

namespace StockManagement.Web.Controllers
{
    [Authorize]
    public class WarehousController : Controller
    {
        private readonly IWarehouseService _warehouseService;
        private readonly IAuditService _auditService;
        public WarehousController(IWarehouseService warehouseService, IAuditService auditService)
        {
            _warehouseService = warehouseService;
            _auditService = auditService;
        }

        public IActionResult Index()
        {
            var warehouses = _warehouseService.TGetAll();
            return View(warehouses);
        }

        [HttpGet]
        public IActionResult AddWarehouse()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddWarehouse(Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                _warehouseService.TCreate(warehouse);
                _auditService.CreateAuditLog(User.Identity.Name, "Create", $"Create Warehouse: {warehouse.Name}, ID: {warehouse.Id}");
                return RedirectToAction("Index");
            }
            else
            {
                return View(warehouse);
            }
        }

        [HttpGet]
        public IActionResult UpdateWarehouse(int id)
        {
            var value = _warehouseService.TGetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateWarehouse(Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                _warehouseService.TUpdate(warehouse);
                _auditService.CreateAuditLog(User.Identity.Name, "Update", $"Update Warehouse: {warehouse.Name}, ID: {warehouse.Id}");
                return RedirectToAction("Index");
            }
            else
            {
                return View(warehouse);
            }
        }

        public IActionResult DeleteWarehouse(int id)
        {
            var value = _warehouseService.TGetById(id);
            if (value is not null)
            {
                _warehouseService.TDelete(value);
                _auditService.CreateAuditLog(User.Identity.Name, "Delete", $"Deleted Warehouse: {value.Name}, ID: {value.Id}");
                return RedirectToAction("Index");
            }
            return View(value);
        }
    }
}
