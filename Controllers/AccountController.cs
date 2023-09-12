using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Models;
using TwitterClone.ViewModels;

namespace TwitterClone.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> _UserManager, SignInManager<User> _SignInManager) {
            userManager = _UserManager;
            signInManager = _SignInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                var newUser = new User
                {
                    Email = newUserVM.Email,
                    UserName = newUserVM.Name,
                    PasswordHash = newUserVM.Password,
                };
                var creationResult = await userManager.CreateAsync(newUser, newUserVM.Password);
                if (creationResult.Succeeded)
                {
                    //create cookie
                    await signInManager.SignInAsync(newUser, false);
                    RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var err in creationResult.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }

            }
            return View(newUserVM);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginUserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(userVM.UserName);
                if (user != null)
                {
                    var passwordMatched = await userManager.CheckPasswordAsync(user, userVM.Password);
                    if (passwordMatched)
                    {
                        await signInManager.SignInAsync(user, userVM.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                    else ModelState.AddModelError("", "invalid Login Info");
                }
                else ModelState.AddModelError("", "no user exists with this username");
            }
            return View(userVM);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
