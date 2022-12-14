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
    using FurnitureHandbook.Services.Data.Hardware;
    using FurnitureHandbook.Services.Data.Images;
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
        private readonly IHardwareService hardwareService;
        private readonly IImagesService imagesService;

        public FurnituresController(IWebHostEnvironment webHostEnvironment, IFurnituresService furnituresService, ITexturesService texturesService, IEdgebandsService edgebandsService, IHardwareService hardwareService, IImagesService imagesService)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.furnituresService = furnituresService;
            this.texturesService = texturesService;
            this.edgebandsService = edgebandsService;
            this.hardwareService = hardwareService;
            this.imagesService = imagesService;
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
            if (Directory.Exists(Path.Combine(wwwRootDirectory, "images/projects")) == false)
            {
                Directory.CreateDirectory(Path.Combine(wwwRootDirectory, "images/projects"));
            }

            var pathToSaveInDb = this.imagesService.UploadImages(inputModel.Image, wwwRootDirectory);

            try
            {
                if (inputModel.TextureId == 0)
                {
                    inputModel.TextureId = await this.texturesService.CreateAsync(inputModel);
                }

                if (inputModel.EdgebandId == 0)
                {
                    inputModel.EdgebandId = await this.edgebandsService.CreateAsync(inputModel);
                }

                inputModel.HardwareId = await this.hardwareService.CreateAsync(inputModel);
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
