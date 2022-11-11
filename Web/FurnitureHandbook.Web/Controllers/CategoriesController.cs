namespace FurnitureHandbook.Web.Controllers
{
    using System.Threading.Tasks;

    using FurnitureHandbook.Services.Data.Categories;
    using FurnitureHandbook.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public async Task<IActionResult> All()
        {
            var viewModel = new CategoriesListViewModel
            {
                Categories = await this.categoriesService.GetAllAsync<CategoryViewModel>(),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> ById(int id)
        {
            var category = await this.categoriesService
                .GetByIdAsync<SingleCategoryViewModel>(id);

            if (category == null)
            {
                return this.NotFound();
            }

            return this.View(category);
        }
    }
}
