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
    using FurnitureHandbook.Web.ViewModels.Documents;
    using FurnitureHandbook.Web.ViewModels.Furnitures;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class EdgebandServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<Edgeband>> mockRepo;
        private readonly EdgebandsService service;

        public EdgebandServiceTests()
        {
            this.mockRepo = EdgebandMockRepository.GetEdgebandMockRepo();
            this.service = new EdgebandsService(this.mockRepo.Object);
        }

        [Fact]
        public async Task CreateEdgebandTest()
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
                TextureId = 6,
                EdgebandName = "Сив мат ГРАФИТ",
                EdgebandManufacturerName = "AGT",
                EdgebandThickness = 1.0,
                HardwareId = 1,
            };

            await this.service.CreateAsync(furnitureModel);

            var count = this.mockRepo.Object.All().Count();
            var name = this.mockRepo.Object.All().Skip(2).First().Name;
            Assert.Equal("Сив мат ГРАФИТ", name);

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
                TextureId = 6,
                EdgebandName = "Бяло гладко",
                EdgebandManufacturerName = "ROSI",
                EdgebandThickness = 0.8,
                HardwareId = 1,
            };

            await Assert.ThrowsAsync<System.Exception>(() => this.service.CreateAsync(furnitureModel));
        }
    }
}
