﻿namespace FurnitureHandbook.Services.Data.Projects
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
        private readonly IDeletableEntityRepository<Client> clientsRepository;

        public ProjectsService(IDeletableEntityRepository<Project> projectsRepository, IDeletableEntityRepository<Client> clientsRepository)
        {
            this.projectsRepository = projectsRepository;
            this.clientsRepository = clientsRepository;
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
