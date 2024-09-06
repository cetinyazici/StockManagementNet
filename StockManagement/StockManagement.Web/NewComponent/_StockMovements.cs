using Microsoft.AspNetCore.Mvc;
using StockManagement.Business.Abstract;

namespace StockManagement.Web.NewComponent
{
    public class _StockMovements : ViewComponent
    {
        private readonly IStockMovementService _movementService;

        public _StockMovements(IStockMovementService movementService)
        {
            _movementService = movementService;
        }
        public IViewComponentResult Invoke()
        {
            var stockMovement = _movementService.TGetAll();
            return View(stockMovement);
        }
    }
}
