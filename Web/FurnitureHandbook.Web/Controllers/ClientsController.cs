namespace FurnitureHandbook.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using FurnitureHandbook.Services.Data.Clients;
    using FurnitureHandbook.Services.Data.Projects;
    using FurnitureHandbook.Web.ViewModels.Clients;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static FurnitureHandbook.Common.GlobalConstants;
    using static FurnitureHandbook.Common.GlobalConstants.Client;

    [Authorize]
    public class ClientsController : Controller
    {
        private readonly IClientsService clientsService;
        private readonly IProjectsService projectsService;

        public ClientsController(
            IClientsService clientsService,
            IProjectsService projectsService)
        {
            this.clientsService = clientsService;
            this.projectsService = projectsService;
        }

        public async Task<IActionResult> All()
        {
            var viewModel = new ClientsListViewModel
            {
                Clients = await this.clientsService.GetAllAsync<ClientViewModel>(),
            };

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            var viewModel = new CreateClientInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClientInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            try
            {
                await this.clientsService.CreateAsync(inputModel);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);

                this.TempData[Message] = ex.Message;

                return this.View(inputModel);
            }

            this.TempData[Message] = ClientAdded;

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
