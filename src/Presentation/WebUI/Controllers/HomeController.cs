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
            //if (!ModelState.IsValid)
            //{
            //    Console.WriteLine("Returning view");
            //    return View(model);

            //    return Json(new
            //    {
            //        error = true,
            //        message = ModelState.ValidationState.ToString()
            //    });
            //}
            //return View();

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
    }
}
