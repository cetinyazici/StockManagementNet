using Microsoft.AspNetCore.Mvc;
using StockManagement.DTO.DTO;

namespace StockManagement.Web.NewComponent
{
    public class _ChangePassword : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new ChangePasswordDTO());
        }
    }
}
