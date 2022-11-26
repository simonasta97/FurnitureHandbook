namespace FurnitureHandbook.Services.Data.Edgebands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Common.Repositories;
    using FurnitureHandbook.Data.Models;
    using FurnitureHandbook.Web.ViewModels.Clients;
    using FurnitureHandbook.Web.ViewModels.Furnitures;
    using Microsoft.EntityFrameworkCore;

    using static FurnitureHandbook.Common.GlobalConstants.Edgeband;

    public class EdgebandsService : IEdgebandsService
    {
        private readonly IDeletableEntityRepository<Edgeband> edgebandsRepository;

        public EdgebandsService(IDeletableEntityRepository<Edgeband> edgebandsRepository)
        {
            this.edgebandsRepository = edgebandsRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.edgebandsRepository
                .AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Name)
                .ToList()
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public async Task<int?> CreateAsync(CreateFurnitureInputModel furnitureModel)
        {
            var isExist = this.edgebandsRepository
                .AllAsNoTracking()
                .Any(x => x.Name == furnitureModel.EdgebandName && x.ManufacturerName == furnitureModel.EdgebandManufacturerName);

            if (isExist)
            {
                throw new Exception(EdgebandAlreadyExist);
            }

            var edgeband = new Edgeband
            {
                Name = furnitureModel.EdgebandName,
                Thickness = furnitureModel.EdgebandThickness,
                ManufacturerName = furnitureModel.EdgebandManufacturerName,
            };

            await this.edgebandsRepository.AddAsync(edgeband);
            await this.edgebandsRepository.SaveChangesAsync();

            var createdEdgeband = this.edgebandsRepository
                .All()
                .FirstOrDefault(x => x.Name == furnitureModel.EdgebandName && x.Thickness == furnitureModel.EdgebandThickness);

            return createdEdgeband.Id;
        }
    }
}
