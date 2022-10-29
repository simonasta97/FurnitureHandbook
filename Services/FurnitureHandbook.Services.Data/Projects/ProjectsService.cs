namespace FurnitureHandbook.Services.Data.Projects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Common.Repositories;
    using FurnitureHandbook.Data.Models;
    using FurnitureHandbook.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class ProjectsService : IProjectsService
    {
        private readonly IDeletableEntityRepository<Project> projectsRepository;

        public ProjectsService(IDeletableEntityRepository<Project> projectsRepository)
        {
            this.projectsRepository = projectsRepository;
        }

        public async Task<IEnumerable<TModel>> GetAllUserProjects<TModel>(string userId, int page, int itemsPerPage = 6)
            => await this.projectsRepository
                .AllAsNoTracking()
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<TModel>()
                .ToListAsync();

        public async Task<int> GetCountAsync()
           => await this.projectsRepository
               .AllAsNoTracking()
               .CountAsync();

        public async Task<TModel> GetByIdAsync<TModel>(string id)
            => await this.projectsRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<TModel>()
                .FirstOrDefaultAsync();
    }
}
