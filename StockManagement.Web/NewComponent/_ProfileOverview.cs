using Microsoft.AspNetCore.Mvc;
using StockManagement.DTO.DTO;

namespace StockManagement.Web.NewComponent
{
    public class _ProfileOverview : ViewComponent
    {
        public IViewComponentResult Invoke(UserInformationDTO model)
        {
            return View(model);
        }
    }
}
