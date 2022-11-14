namespace FurnitureHandbook.Services.Data.Furnitures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Common.Repositories;
    using FurnitureHandbook.Data.Models;
    using FurnitureHandbook.Services.Mapping;
    using FurnitureHandbook.Web.ViewModels.Furnitures;
    using FurnitureHandbook.Web.ViewModels.Projects;
    using Microsoft.EntityFrameworkCore;

    using static FurnitureHandbook.Common.GlobalConstants.Furniture;

    public class FurnituresService : IFurnituresService
    {
        private readonly IDeletableEntityRepository<Furniture> furnituresRepository;

        public FurnituresService(IDeletableEntityRepository<Furniture> furnituresRepository)
        {
            this.furnituresRepository = furnituresRepository;
        }

        public async Task CreateAsync(CreateFurnitureInputModel furnitureModel, string pathToSaveInDb)
        {

            var furniture = new Furniture
            {
                ProjectId = furnitureModel.ProjectId,
                Name = furnitureModel.Name,
                Color = furnitureModel.Color,
                ImageUrl = pathToSaveInDb,
                Length = furnitureModel.Length,
                Width = furnitureModel.Width,
                Depth = furnitureModel.Depth,
            };

            await this.furnituresRepository.AddAsync(furniture);
            await this.furnituresRepository.SaveChangesAsync();
        }

        public async Task<TModel> GetByIdAsync<TModel>(int id)
             => await this.furnituresRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<TModel>()
                .FirstOrDefaultAsync();

        public string GetProjectIdByFurnitureId(int id)
            => this.furnituresRepository
                .All()
                .FirstOrDefault(x => x.Id == id).ProjectId;

        public async Task DeleteAsync(int id)
        {
            var furniture = await this.furnituresRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (furniture == null)
            {
                throw new Exception(FurnitureNotFound);
            }

            this.furnituresRepository.Delete(furniture);
            await this.furnituresRepository.SaveChangesAsync();
        }
    }
}
