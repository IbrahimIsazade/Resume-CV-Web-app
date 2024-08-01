using Microsoft.AspNetCore.Mvc;
using Services.Categories;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController(ICategoryService categoryService) : Controller
    {
        public IActionResult Categories()
        {
            return View();
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryRequestDto category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await categoryService.AddAsync(category);

            return RedirectToAction("Categories");
        }

        public IActionResult EditCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(EditCategoryDto category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await categoryService.Edit(category);

            return RedirectToAction("Categories");
        }



        [HttpPost]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            var result = await categoryService.Remove(id);

            if (!result) 
            {
                return RedirectToAction("Failed");
            }

            return RedirectToAction("Categories");
        }
    }
}
