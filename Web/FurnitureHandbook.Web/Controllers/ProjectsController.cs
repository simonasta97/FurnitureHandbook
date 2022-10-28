namespace FurnitureHandbook.Web.Controllers
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using FurnitureHandbook.Services.Data.Projects;
    using FurnitureHandbook.Web.ViewModels.Projects;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    public class ProjectsController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IProjectsService projectsService;

        public ProjectsController(IWebHostEnvironment webHostEnvironment, IProjectsService projectsService)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.projectsService = projectsService;
        }

        public async Task<IActionResult> All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var userId = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            const int ItemsPerPage = 6;

            var viewModel = new ProjectsListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Count = await this.projectsService.GetCountAsync(),
                Projects = await this.projectsService.GetAllUserProjects<ProjectViewModel>(userId, id, ItemsPerPage),
            };

            return this.View(viewModel);
        }
    }
}
