namespace FurnitureHandbook.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using FurnitureHandbook.Services.Data.Categories;
    using FurnitureHandbook.Services.Data.Clients;
    using FurnitureHandbook.Services.Data.Edgebands;
    using FurnitureHandbook.Services.Data.Furnitures;
    using FurnitureHandbook.Services.Data.Textures;
    using FurnitureHandbook.Web.ViewModels.Categories;
    using FurnitureHandbook.Web.ViewModels.Furnitures;
    using FurnitureHandbook.Web.ViewModels.Projects;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using static FurnitureHandbook.Common.GlobalConstants;
    using static FurnitureHandbook.Common.GlobalConstants.Furniture;

    [Authorize]
    public class FurnituresController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        private readonly IFurnituresService furnituresService;
        private readonly ITexturesService texturesService;
        private readonly IEdgebandsService edgebandsService;
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "pdf" };

        public FurnituresController(IWebHostEnvironment webHostEnvironment, IFurnituresService furnituresService, ITexturesService texturesService, IEdgebandsService edgebandsService)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.furnituresService = furnituresService;
            this.texturesService = texturesService;
            this.edgebandsService = edgebandsService;
        }

        public IActionResult Create(string projectId)
        {
            var viewModel = new CreateFurnitureInputModel();
            viewModel.ProjectId = projectId;
            viewModel.Textures = this.texturesService.GetAllAsKeyValuePairs();
            viewModel.Edgebands = this.edgebandsService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string projectId, CreateFurnitureInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.Textures = this.texturesService.GetAllAsKeyValuePairs();
                inputModel.Edgebands = this.edgebandsService.GetAllAsKeyValuePairs();
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

                inputModel.Textures = this.texturesService.GetAllAsKeyValuePairs();
                inputModel.Edgebands = this.edgebandsService.GetAllAsKeyValuePairs();

                this.TempData[Message] = ex.Message;

                return this.View(inputModel);
            }

            this.TempData[Message] = FurnitureAdded;
            return this.RedirectToAction("ById", "Projects", new { id = projectId });
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
            var furnitureProjectId = this.furnituresService.GetProjectIdByFurnitureId(id);
            await this.furnituresService.DeleteAsync(id);
            return this.RedirectToAction("ById", "Projects", new { id = furnitureProjectId });
        }
    }
}
