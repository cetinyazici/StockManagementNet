using Microsoft.AspNetCore.Mvc;

namespace StockManagement.Web.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
