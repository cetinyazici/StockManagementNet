using Microsoft.AspNetCore.Mvc;
using StockManagement.Business.Abstract;

namespace StockManagement.Web.Controllers
{
    public class StockMovementController : Controller
    {
        private readonly IStockMovementService _stockMovementService;

        public StockMovementController(IStockMovementService stockMovementService)
        {
            _stockMovementService = stockMovementService;
        }

        public IActionResult Index()
        {
            var StockMovements = _stockMovementService.TGetAll();
            return View(StockMovements);
        }
    }
}
