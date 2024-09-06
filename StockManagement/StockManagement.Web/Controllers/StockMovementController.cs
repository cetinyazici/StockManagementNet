using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Business.Abstract;
using StockManagement.DTO.DTO;

namespace StockManagement.Web.Controllers
{
    [Authorize]
    public class StockMovementController : Controller
    {
        private readonly IStockMovementService _stockMovementService;
        private readonly IMapper _mapper;

        public StockMovementController(IStockMovementService stockMovementService, IMapper mapper)
        {
            _stockMovementService = stockMovementService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var stockMovements = _stockMovementService.GetAllWithDetails();
            var viewModelList = _mapper.Map<List<StockMovementDTO>>(stockMovements);
            return View(viewModelList);
        }
    }
}
