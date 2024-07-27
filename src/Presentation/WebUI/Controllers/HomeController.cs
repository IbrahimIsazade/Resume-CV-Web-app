using Domain.Entities.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.ContactPost;
using System.Security.Claims;

namespace WebUI.Controllers
{
    public class HomeController(IContactPostService contactPostService, UserManager<MoticvUser> userManager) : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Contact()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("/send-contact")]
        public async Task<IActionResult> SendContact(AddContactPostRequestDto model)
        {

            var error = ModelState.Values
                               .SelectMany(v => v.Errors)
                               .Select(e => e.ErrorMessage)
                               .FirstOrDefault();

            if (error != null)
            {
                return Json(new
                {
                    error = true,
                    message = error
                });
            }


            var res = await contactPostService.Add(model);

            if (res.Error)
                return Json(new
                {
                    error = res.Error,
                    message = res.Message
                });

            return Json(new
            {
                error = res.Error,
                message = res.Message
            });
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
