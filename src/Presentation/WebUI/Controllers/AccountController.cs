using Domain.Entities.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController(UserManager<MoticvUser> userManager, SignInManager<MoticvUser> signInManager) : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email, string password)
        {
            var user = new MoticvUser
            {
                UserName = email,
                Email = email
            };

            var result = await userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }

                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [Route("/login.html")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("/login.html")]
        public async Task<IActionResult> LoginUser(string email, string password)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user is null)
            {
                ModelState.AddModelError("User", "Username or password is incorrect");
                goto l1;
            }

            var result = await signInManager.PasswordSignInAsync(user, password, true, true);

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("User", "Account has been locked temporarily. Please try again later");
                goto l1;
            }
            else if (!result.Succeeded)
            {
                ModelState.AddModelError("User", "Username or password is incorrect");
                goto l1;
            }

            string? callbackUrl = Request.Query["ReturnUrl"];

            if (!string.IsNullOrWhiteSpace(callbackUrl))
            {
                return Redirect(callbackUrl);
            }

            return RedirectToAction("Index", "Home");
        l1:
            return View();
        }
    }
}
