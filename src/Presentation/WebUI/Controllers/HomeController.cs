using Microsoft.AspNetCore.Mvc;
using Services.ContactPost;

namespace WebUI.Controllers
{
    public class HomeController(IContactPostService contactPostService) : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AddContactPostRequestDto model)
        {
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

        //public IActionResult EditResume()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> EditResume()
        //{
        //    return View();
        //}
    }
}
