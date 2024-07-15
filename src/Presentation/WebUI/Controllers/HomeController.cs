using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditResume()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> EditResume()
        //{
        //    return View();
        //}
    }
}
