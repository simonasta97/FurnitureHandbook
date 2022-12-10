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
    using FurnitureHandbook.Web.ViewModels.Projects;
    using Microsoft.EntityFrameworkCore;

    using static System.Net.Mime.MediaTypeNames;
    using static FurnitureHandbook.Common.GlobalConstants.Project;

    public class ProjectsService : IProjectsService
    {
        private readonly IDeletableEntityRepository<Project> projectsRepository;

        public ProjectsService(IDeletableEntityRepository<Project> projectsRepository)
        {
            this.projectsRepository = projectsRepository;
        }

        public async Task CreateAsync(CreateProjectInputModel projectModel, string pathToSaveInDb)
        {
            if (projectModel.StartDate > projectModel.EndDate)
            {
                throw new Exception(StartBeforeEndDate);
            }


            var project = new Project
            {
                UserId = projectModel.UserId,
                Title = projectModel.Title,
                Description = projectModel.Description,
                ImageUrl = pathToSaveInDb,
                Status = projectModel.Status,
                StartDate = projectModel.StartDate,
                EndDate = projectModel.EndDate,
                TotalPrice = projectModel.TotalPrice,
                DownPayment = projectModel.DownPayment,
                ClientId = projectModel.ClientId,
                CategoryId = projectModel.CategoryId,
            };

            await this.projectsRepository.AddAsync(project);
            await this.projectsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllUserProjects<TModel>(string userId, int page, int itemsPerPage = 6)
            => await this.projectsRepository
                .AllAsNoTracking()
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<TModel>()
                .ToListAsync();

        public async Task<IEnumerable<TModel>> FilterProjectsStatus<TModel>(string userId, string status, int page, int itemsPerPage = 6)
            => await this.projectsRepository
                .AllAsNoTracking()
                .Where(x => x.UserId == userId && x.Status == Enum.Parse<StatusType>(status))
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

        public async Task UpdateAsync(string id, EditProjectInputModel projectModel)
        {
            if (id == null)
            {
                throw new Exception(ProjectNotFound);
            }

            var project = this.projectsRepository
                .All()
                .FirstOrDefault(x => x.Id == id);

            project.Title = projectModel.Title;
            project.Description = projectModel.Description;
            project.Status = projectModel.Status;
            project.StartDate = projectModel.StartDate;
            project.EndDate = projectModel.EndDate;
            project.TotalPrice = projectModel.TotalPrice;
            project.DownPayment = projectModel.DownPayment;

            await this.projectsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var project = this.projectsRepository
                .All()
                .FirstOrDefault(x => x.Id == id);

            if (project == null)
            {
                throw new Exception(ProjectNotFound);
            }

            this.projectsRepository.Delete(project);
            await this.projectsRepository.SaveChangesAsync();
        }
    }
}
