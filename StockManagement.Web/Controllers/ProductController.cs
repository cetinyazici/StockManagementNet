using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Business.Abstract;
using StockManagement.DTO.DTO;
using StockManagement.Entities.Concrete;

namespace StockManagement.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllWithDetails();
            var viewModelList = _mapper.Map<List<ProductDTO>>(products);
            return View(viewModelList);
        }
    }
}
