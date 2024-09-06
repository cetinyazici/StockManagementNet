using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockManagement.DTO.DTO;
using StockManagement.Entities.Concrete;

namespace StockManagement.Web.NewComponent
{
    public class _ProfileEdit : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _ProfileEdit(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync((System.Security.Claims.ClaimsPrincipal)User);
            if (user == null)
            {
                return Content("User not found");
            }

            var model = new UserInformationDTO
            {
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email,
            };

            return View(model);
        }
    }
}