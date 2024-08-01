using Microsoft.AspNetCore.Mvc;

namespace StockManagement.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error404(string code)
        {
            return View();
        }
    }
}
