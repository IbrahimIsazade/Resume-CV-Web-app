using Microsoft.AspNetCore.Mvc;
using Services.Categories;

namespace WebUI.Areas.Admin.ViewComponents
{
    public class AllCategoriesViewComponent(ICategoryService categoryService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string view = null)
        {
            var res = await categoryService.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(view))
                return View(view, res);

            return View(res);
        }
    }
}
