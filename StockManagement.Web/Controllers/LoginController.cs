using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Entities.Concrete;
using StockManagement.Web.Models;

namespace StockManagement.Web.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(UserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password == model.ConfirmPassword)
                {
                    if (model.Terms)
                    {
                        var appUser = new AppUser
                        {
                            Email = model.Email,
                            UserName = model.UserName,
                        };

                        var result = await _userManager.CreateAsync(appUser, model.Password);
                        if (result.Succeeded)
                        {
                            await _signInManager.SignInAsync(appUser, isPersistent: false);
                            return RedirectToAction("SignIn");
                        }
                        else
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "You must agree to the terms and conditions.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Passwords do not match.");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(UserSigInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: false, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Product"); 
                }
                else if (result.IsLockedOut)
                {
                    return View("Lockout"); 
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
                }
            }
            return View(model);
        }

    }
}
