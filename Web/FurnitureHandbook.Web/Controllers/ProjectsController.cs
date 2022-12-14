namespace FurnitureHandbook.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using FurnitureHandbook.Services.Data.Categories;
    using FurnitureHandbook.Services.Data.Clients;
    using FurnitureHandbook.Services.Data.Images;
    using FurnitureHandbook.Services.Data.Projects;
    using FurnitureHandbook.Web.ViewModels.Projects;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    using static FurnitureHandbook.Common.GlobalConstants;
    using static FurnitureHandbook.Common.GlobalConstants.Project;

    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IProjectsService projectsService;
        private readonly ICategoriesService categoriesService;
        private readonly IClientsService clientsService;
        private readonly IImagesService imagesService;

        public ProjectsController(
            IWebHostEnvironment webHostEnvironment,
            IProjectsService projectsService,
            ICategoriesService categoriesService,
            IClientsService clientsService,
            IImagesService imagesService)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.projectsService = projectsService;
            this.categoriesService = categoriesService;
            this.clientsService = clientsService;
            this.imagesService = imagesService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateProjectInputModel();
            viewModel.Categories = this.categoriesService.GetAllAsKeyValuePairs();
            viewModel.Clients = this.clientsService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.Categories = this.categoriesService.GetAllAsKeyValuePairs();
                inputModel.Clients = this.clientsService.GetAllAsKeyValuePairs();
                return this.View(inputModel);
            }

            inputModel.UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var wwwRootDirectory = this.webHostEnvironment.WebRootPath;
            if (Directory.Exists(Path.Combine(wwwRootDirectory, "images/projects")) == false)
            {
                Directory.CreateDirectory(Path.Combine(wwwRootDirectory, "images/projects"));
            }

            var pathToSaveInDb = this.imagesService.UploadImages(inputModel.Image, wwwRootDirectory);

            try
            {
                await this.projectsService.CreateAsync(inputModel, pathToSaveInDb);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);

                inputModel.Categories = this.categoriesService.GetAllAsKeyValuePairs();
                inputModel.Clients = this.clientsService.GetAllAsKeyValuePairs();

                this.TempData[Message] = ex.Message;

                return this.View(inputModel);
            }

            this.TempData[Message] = ProjectAdded;

            return this.RedirectToAction(nameof(this.All));
        }

        public async Task<IActionResult> All(string status, int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var userId = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            const int ItemsPerPage = 4;

            var viewModel = new ProjectsListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Count = await this.projectsService.GetCountAsync(),
                Projects = status == null
                    ? await this.projectsService.GetAllUserProjects<ProjectViewModel>(userId, id, ItemsPerPage)
                    : await this.projectsService.FilterProjectsStatus<ProjectViewModel>(userId, status, id, ItemsPerPage),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> ById(string id)
        {
            var trip = await this.projectsService
                .GetByIdAsync<SingleProjectViewModel>(id);

            return this.View(trip);
        }

        public IActionResult Edit(string id)
        {
            var inputModel = this.projectsService.GetByIdAsync<EditProjectInputModel>(id).Result;

            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditProjectInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.projectsService.UpdateAsync(id, inputModel);
            return this.RedirectToAction(nameof(this.ById), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            await this.projectsService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
