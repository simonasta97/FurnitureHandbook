namespace FurnitureHandbook.Web.Controllers
{
    using System.Threading.Tasks;

    using FurnitureHandbook.Services.Data.Categories;
    using FurnitureHandbook.Services.Data.Furnitures;
    using FurnitureHandbook.Web.ViewModels.Categories;
    using FurnitureHandbook.Web.ViewModels.Furnitures;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class FurnituresController : Controller
    {
        private readonly IFurnituresService furnituresService;

        public FurnituresController(IFurnituresService furnituresService)
        {
            this.furnituresService = furnituresService;
        }

        public async Task<IActionResult> ById(int id)
        {
            var furniture = await this.furnituresService
                .GetByIdAsync<SingleFurnitureViewModel>(id);

            if (furniture == null)
            {
                return this.NotFound();
            }

            return this.View(furniture);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.furnituresService.DeleteAsync(id);
            return this.RedirectToAction("All", "Projects");
        }
    }
}
