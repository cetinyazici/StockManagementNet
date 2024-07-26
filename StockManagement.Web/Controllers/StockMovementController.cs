using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Business.Abstract;
using StockManagement.DTO.DTO;

namespace StockManagement.Web.Controllers
{
    public class StockMovementController : Controller
    {
        private readonly IStockMovementService _stockMovementService;
        private readonly IProductService _productService;
        private readonly IWarehouseService _warehouseService;
        private readonly IMapper _mapper;

        public StockMovementController(IStockMovementService stockMovementService, IProductService productService, IWarehouseService warehouseService, IMapper mapper)
        {
            _stockMovementService = stockMovementService;
            _productService = productService;
            _warehouseService = warehouseService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            // Stok hareketlerini al
            var stockMovements = _stockMovementService.TGetAll();

            // Ürün ve depo adlarını al
            var productNames = _productService.TGetAll().ToDictionary(p => p.Id, p => p.Name);
            var warehouseNames = _warehouseService.TGetAll().ToDictionary(w => w.Id, w => w.Name);

            // Stok hareketlerini DTO'ya dönüştür
            var viewModelList = stockMovements.Select(sm => new StockMovementDTO
            {
                Id = sm.Id,
                ProductName = productNames.ContainsKey(sm.ProductId) ? productNames[sm.ProductId] : "Unknown",
                WarehouseName = warehouseNames.ContainsKey(sm.WarehouseId) ? warehouseNames[sm.WarehouseId] : "Unknown",
                Quantity = sm.Quantity,
                MovementDate = sm.MovementDate,
                MovementType = sm.MovementType
            }).ToList();

            // View'e gönder
            return View(viewModelList);
        }
    }
}
