using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Business.Abstract;
using StockManagement.DataAccess.Concretes;
using StockManagement.DataAccess.DbContexts;
using StockManagement.DTO.DTO;
using StockManagement.Entities.Concrete;
using StockManagement.Web.Models;

namespace StockManagement.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISupplierService _supplierService;
        private readonly ICategoryService _categoryService;
        private readonly IWarehouseService _warehouseService;
        private readonly IStockMovementService _stockMovementService;
        private readonly IAuditService _auditService;
        private readonly IMapper _mapper;

        public ProductController(
            IProductService productService,
            IMapper mapper,
            ISupplierService supplierService,
            ICategoryService categoryService,
            IWarehouseService warehouseService,
            IStockMovementService stockMovementService,
            IAuditService auditService)
        {
            _productService = productService;
            _mapper = mapper;
            _supplierService = supplierService;
            _categoryService = categoryService;
            _warehouseService = warehouseService;
            _stockMovementService = stockMovementService;
            _auditService = auditService;
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

            _auditService.CreateAuditLog(User.Identity.Name, "Create", $"Product Created: {product.Name}, ID: {product.Id}, Barcode: {product.Barcode}");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var product = _productService.TGetById(id);
            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductUpdateViewModel
            {
                Product = _mapper.Map<ProductUpdateDTO>(product),
                Suppliers = _supplierService.TGetAll(),
                Categories = _categoryService.TGetAll(),
                Warehouses = _warehouseService.TGetAll()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProduct(ProductUpdateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Suppliers = _supplierService.TGetAll();
                viewModel.Categories = _categoryService.TGetAll();
                viewModel.Warehouses = _warehouseService.TGetAll();
                return View(viewModel);
            }

            var product = _productService.TGetById(viewModel.Product.Id);
            if (product == null)
            {
                return NotFound();
            }

            _mapper.Map(viewModel.Product, product);

            // StockMovements güncelleme
            product.StockMovements.Clear();
            product.StockMovements = viewModel.Product.SelectedWarehouseIds.Select(id => new StockMovement
            {
                WarehouseId = id,
                Quantity = viewModel.Product.StockQuantity,
                MovementType = "In",
                MovementDate = DateTime.Now,
                Product = product
            }).ToList();

            _productService.TUpdate(product);

            _auditService.CreateAuditLog(User.Identity.Name, "Update", $"Product Updated: {product.Name}, ID: {product.Id}, Barcode: {product.Barcode}");
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            var values = _productService.TGetById(id);
            if (values is not null)
            {
                _productService.TDelete(values);
                _auditService.CreateAuditLog(User.Identity.Name, "Delete", $"Product Deleted: {values.Name}, ID: {values.Id}, Barcode: {values.Barcode}");
                return RedirectToAction("Index");
            }
            return View(values);
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
