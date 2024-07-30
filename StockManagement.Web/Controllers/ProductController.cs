using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Business.Abstract;
using StockManagement.DataAccess.Concretes;
using StockManagement.DTO.DTO;
using StockManagement.Entities.Concrete;
using StockManagement.Web.Models;

namespace StockManagement.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISupplierService _supplierService;
        private readonly ICategoryService _categoryService;
        private readonly IWarehouseService _warehouseService;
        private readonly IStockMovementService _stockMovementService;
        private readonly IMapper _mapper;

        public ProductController(
            IProductService productService, 
            IMapper mapper, 
            ISupplierService supplierService, 
            ICategoryService categoryService,
            IWarehouseService warehouseService,
            IStockMovementService stockMovementService)
        {
            _productService = productService;
            _mapper = mapper;
            _supplierService = supplierService;
            _categoryService = categoryService;
            _warehouseService = warehouseService;
            _stockMovementService = stockMovementService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllWithDetails();
            var viewModelList = _mapper.Map<List<ProductDTO>>(products);
            return View(viewModelList);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            var suppliers = _supplierService.TGetAll();
            var categories = _categoryService.TGetAll();
            var warehouses = _warehouseService.TGetAll();

            var viewModel = new ProductCreateViewModel
            {
                Suppliers = suppliers,
                Categories = categories,
                Warehouses = warehouses,

            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(ProductCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // Hataları kontrol et
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    // Hataları logla veya konsola yazdır
                    Console.WriteLine(error.ErrorMessage);
                }

                // ViewModel'i tekrar yükle ve formu göster
                viewModel.Suppliers = _supplierService.TGetAll();
                viewModel.Categories = _categoryService.TGetAll();
                viewModel.Warehouses = _warehouseService.TGetAll();
                return View("AddProduct", viewModel);
            }

            var product = _mapper.Map<Product>(viewModel.Product);
            _productService.TCreate(product);
            AddStockMovements(viewModel.WarehouseIds, viewModel.Product.StockQuantity, product.Id);

            return RedirectToAction("Index");
        }




        private void AddStockMovements(IEnumerable<int> warehouseIds, int stockQuantity, int productId)
        {
            foreach (var warehouseId in warehouseIds)
            {
                var stockMovement = new StockMovement
                {
                    ProductId = productId,
                    WarehouseId = warehouseId,
                    Quantity = stockQuantity,
                    MovementDate = DateTime.Now,
                    MovementType = "In" 
                };
                _stockMovementService.TCreate(stockMovement);
            }
        }



    }
}
