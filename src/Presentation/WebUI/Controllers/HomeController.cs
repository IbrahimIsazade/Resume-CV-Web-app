using Microsoft.AspNetCore.Mvc;
using Services.ContactPost;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactPostService contactPostService;

        public HomeController(IContactPostService contactPostService)
        {
            this.contactPostService = contactPostService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AddContactPostRequestDto model)
        {
            try
            {
                await contactPostService.Add(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
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
