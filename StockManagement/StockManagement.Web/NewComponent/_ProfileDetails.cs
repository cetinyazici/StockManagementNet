using Microsoft.AspNetCore.Mvc;
using StockManagement.DTO.DTO;

namespace StockManagement.Web.NewComponent
{
    public class _ProfileDetails : ViewComponent
    {
        public IViewComponentResult Invoke(UserInformationDTO model)
        {
            return View(model);
        }
    }
}
