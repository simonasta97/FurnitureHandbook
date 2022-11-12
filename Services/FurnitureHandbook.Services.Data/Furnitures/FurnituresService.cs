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
    using Microsoft.EntityFrameworkCore;

    public class FurnituresService : IFurnituresService
    {
        private readonly IDeletableEntityRepository<Furniture> furnituresRepository;

        public FurnituresService(IDeletableEntityRepository<Furniture> furnituresRepository)
        {
            this.furnituresRepository = furnituresRepository;
        }

        public async Task<TModel> GetByIdAsync<TModel>(int id)
             => await this.furnituresRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<TModel>()
                .FirstOrDefaultAsync();
    }
}
