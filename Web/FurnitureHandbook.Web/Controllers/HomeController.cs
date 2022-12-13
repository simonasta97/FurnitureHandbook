namespace FurnitureHandbook.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using FurnitureHandbook.Services.Data.Projects;
    using FurnitureHandbook.Web.ViewModels;
    using FurnitureHandbook.Web.ViewModels.Home;
    using FurnitureHandbook.Web.ViewModels.Projects;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;

    using static FurnitureHandbook.Common.GlobalConstants.Cache;

    public class HomeController : BaseController
    {
        private readonly IProjectsService projectsService;
        private readonly IMemoryCache cache;

        public HomeController(
            IProjectsService projectsService,
            IMemoryCache cache)
        {
            this.projectsService = projectsService;
            this.cache = cache;
        }

        public async Task<IActionResult> Index()
        {
            var latestProjects = this.cache.Get<List<LatestProjectViewModel>>(LatestProjectsCacheKey);

            if (latestProjects == null)
            {
                latestProjects = this.projectsService
                   .Latest<LatestProjectViewModel>()
                   .ToList();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(30));

                this.cache.Set(LatestProjectsCacheKey, latestProjects, cacheOptions);
            }

            var viewModel = new HomeViewModel
            {
                Projects = latestProjects,
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
