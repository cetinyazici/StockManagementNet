using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockManagement.DTO.DTO;
using StockManagement.Entities.Concrete;
using StockManagement.Web.Models;

namespace StockManagement.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var model = new ProfileViewModel
            {
                UserInformation = new UserInformationDTO
                {
                    Id = user.Id,
                    Name = user.UserName,
                    Email = user.Email
                },
                ChangePassword = new ChangePasswordDTO()
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(UserInformationDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id.ToString());
                if (user != null)
                {
                    user.UserName = model.Name;
                    user.Email = model.Email;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Profile");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User not found");
                }
            }
            var viewModel = new ProfileViewModel
            {
                UserInformation = model,
                ChangePassword = new ChangePasswordDTO()
            };
            return View("Profile", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        // Kullanıcı şifre değiştirdikten sonra giriş yapmasını sağlamak için oturumu sonlandırıyoruz.
                        await _userManager.UpdateSecurityStampAsync(user);
                        await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

                        return RedirectToAction("SignIn", "Account");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User not found");
                }
            }

            var userForView = await _userManager.GetUserAsync(User);

            var viewModel = new ProfileViewModel
            {
                UserInformation = new UserInformationDTO
                {
                    Id = userForView.Id,
                    Name = userForView.UserName,
                    Email = userForView.Email
                },
                ChangePassword = model
            };

            return View("Profile", viewModel);
        }

    }
}
