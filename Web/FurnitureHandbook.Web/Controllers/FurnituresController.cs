namespace FurnitureHandbook.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using FurnitureHandbook.Services.Data.Categories;
    using FurnitureHandbook.Services.Data.Furnitures;
    using FurnitureHandbook.Web.ViewModels.Categories;
    using FurnitureHandbook.Web.ViewModels.Furnitures;
    using FurnitureHandbook.Web.ViewModels.Projects;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    using static FurnitureHandbook.Common.GlobalConstants;
    using static FurnitureHandbook.Common.GlobalConstants.Furniture;

    [Authorize]
    public class FurnituresController : Controller
    {
        private readonly IFurnituresService furnituresService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "pdf" };

        public FurnituresController(IWebHostEnvironment webHostEnvironment, IFurnituresService furnituresService)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.furnituresService = furnituresService;
        }

        public IActionResult Create(string projectId)
        {
            var viewModel = new CreateFurnitureInputModel();
            viewModel.ProjectId = projectId;
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string projectId, CreateFurnitureInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            inputModel.ProjectId = projectId;

            var wwwRootDirectory = this.webHostEnvironment.WebRootPath;
            if (Directory.Exists(Path.Combine(wwwRootDirectory, "images/furnitures")) == false)
            {
                Directory.CreateDirectory(Path.Combine(wwwRootDirectory, "images/furnitures"));
            }

            var image = inputModel.Image;

            var name = image.FileName;
            var extension = Path.GetExtension(image.FileName).TrimStart('.');

            if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
            {
                throw new Exception($"Невалиден формат на снимката - {extension}");
            }

            var path = Path.Combine(wwwRootDirectory, "images/furnitures/", image.FileName);
            var pathToSaveInDb = Path.Combine("/images/furnitures/", image.FileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }

            try
            {
                await this.furnituresService.CreateAsync(inputModel, pathToSaveInDb);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);

                this.TempData[Message] = ex.Message;

                return this.View(inputModel);
            }

            this.TempData[Message] = FurnitureAdded;
            return this.RedirectToAction("All", "Projects");
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
