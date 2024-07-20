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

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [Route("/send-contact")]
        public async Task<IActionResult> SendContact(AddContactPostRequestDto model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        return Json(new
                        {
                            error = true,
                            message = error.ErrorMessage
                        });
                    }
                }

                
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
    }
}
