namespace FurnitureHandbook.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Common.Repositories;
    using FurnitureHandbook.Data.Models;
    using FurnitureHandbook.Services.Data.Edgebands;
    using FurnitureHandbook.Services.Data.Tests.Mocks;
    using FurnitureHandbook.Services.Data.Textures;
    using FurnitureHandbook.Web.ViewModels.Furnitures;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class TextureServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<Texture>> mockRepo;
        private readonly TexturesService service;

        public TextureServiceTests()
        {
            this.mockRepo = TextureMockRepository.GetTextureMockRepo();
            this.service = new TexturesService(this.mockRepo.Object);
        }

        [Fact]
        public async Task CreateTextureTest()
        {
            var imageFurniture = new Mock<IFormFile>();

            var furnitureModel = new CreateFurnitureInputModel
            {
                Name = "Кухня",
                Image = imageFurniture.Object,
                Color = "Сив мат с дъб Кендъл",
                Length = 438,
                Depth = 55,
                Width = 85,
                TextureName = "БЯЛО ГЛАДКО",
                TextureManufacturerName = "KASTAMONU",
                TextureCode = "F235e",
                TextureType = TextureType.CHIPBOARD,
                EdgebandId = 2,
                HardwareId = 1,
            };

            await this.service.CreateAsync(furnitureModel);

            var count = this.mockRepo.Object.All().Count();
            var name = this.mockRepo.Object.All().Skip(2).First().Name;
            Assert.Equal("БЯЛО ГЛАДКО", name);

            Assert.True(count == 3);
        }

        [Fact]
        public async Task CreateEdgebandExceptionTest()
        {
            var imageFurniture = new Mock<IFormFile>();

            var furnitureModel = new CreateFurnitureInputModel
            {
                Name = "Кухня",
                Image = imageFurniture.Object,
                Color = "Сив мат с дъб Кендъл",
                Length = 438,
                Depth = 55,
                Width = 85,
                TextureName = "ТЪМНА АНКОНА",
                TextureManufacturerName = "KASTAMONU",
                TextureCode = "512 Frz",
                TextureType = TextureType.CHIPBOARD,
                EdgebandId = 2,
                HardwareId = 1,
            };

            await Assert.ThrowsAsync<System.Exception>(() => this.service.CreateAsync(furnitureModel));
        }
    }
}
