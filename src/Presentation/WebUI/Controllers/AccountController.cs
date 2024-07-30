using Domain.Entities.Membership;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user is null)
            {
                ModelState.AddModelError("User", "Username or password is incorrect");
                goto l1;
            }

            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email)) 
            {
                ModelState.AddModelError("User", "Username or password cannot be empty");
                goto l1;
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, password, true);

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("User", "Account has been locked temporarily. Please try again later");
                goto l1;
            }
            else if (!result.Succeeded)
            {
                ModelState.AddModelError("User", "Username or password is incorrect");
                goto l1;
            }else if (!user.EmailConfirmed)
            {
                ModelState.AddModelError("User", "Email not confirmed !");
                goto l1;
            }

            var claims = new List<Claim> {
    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
};

            var now = DateTime.UtcNow;
            var properties = new AuthenticationProperties
            {
                IsPersistent = true,
                IssuedUtc = now,
                ExpiresUtc = now.AddMinutes(2)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await Request.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, properties);

            string? callbackUrl = Request.Query["ReturnUrl"];

            if (!string.IsNullOrWhiteSpace(callbackUrl))
            {
                Console.WriteLine($"---==[ CALLBACK: {callbackUrl} ]==---");
                return Redirect(callbackUrl);
            }

            return RedirectToAction("Index", "Home");
        l1:
            return View();
        }

        public async Task<string> Logout()
        {
            await signInManager.SignOutAsync();

            return "Succesfully logout";
        }
    }
}
