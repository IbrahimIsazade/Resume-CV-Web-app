using Microsoft.AspNetCore.Mvc;
using Services.ContactPost;

namespace WebUI.Controllers
{
    // (IContactPostService contactPostService)
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        //[HttpPost]
        //[Route("/send-contact")]
        //public async Task<IActionResult> SendContact(AddContactPostRequestDto model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        foreach (var state in ModelState)
        //        {
        //            foreach (var error in state.Value.Errors)
        //            {
        //                return Json(new
        //                {
        //                    error = true,
        //                    message = error.ErrorMessage
        //                });
        //            }
        //        }
        //    }

        //    var res = await contactPostService.Add(model);

        //    if (res.Error)
        //        return Json(new
        //        {
        //            error = res.Error,
        //            message = res.Message
        //        });

        //    return Json(new
        //    {
        //        error = res.Error,
        //        message = res.Message
        //    });
        //}
    }
}
