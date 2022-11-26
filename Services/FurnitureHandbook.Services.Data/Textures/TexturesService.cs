namespace FurnitureHandbook.Services.Data.Textures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Common.Repositories;
    using FurnitureHandbook.Data.Models;
    using FurnitureHandbook.Web.ViewModels.Furnitures;

    using static FurnitureHandbook.Common.GlobalConstants.Texture;

    public class TexturesService : ITexturesService
    {
        private readonly IDeletableEntityRepository<Texture> texturesRepository;

        public TexturesService(IDeletableEntityRepository<Texture> texturesRepository)
        {
            this.texturesRepository = texturesRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.texturesRepository
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
            var isExist = this.texturesRepository
                .AllAsNoTracking()
                .Any(x => x.Name == furnitureModel.TextureName && x.TextureCode == furnitureModel.TextureCode);

            if (isExist)
            {
                throw new Exception(TextureAlreadyExist);
            }

            var texture = new Texture
            {
                Name = furnitureModel.TextureName,
                Type = furnitureModel.TextureType,
                ManufacturerName = furnitureModel.TextureManufacturerName,
                TextureCode = furnitureModel.TextureCode,
            };

            await this.texturesRepository.AddAsync(texture);
            await this.texturesRepository.SaveChangesAsync();

            var createdTexture = this.texturesRepository
                .All()
                .FirstOrDefault(x => x.Name == furnitureModel.TextureName && x.TextureCode == furnitureModel.TextureCode);

            return createdTexture.Id;
        }
    }
}
