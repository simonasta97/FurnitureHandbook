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
    using FurnitureHandbook.Services.Data.Hardware;
    using FurnitureHandbook.Services.Data.Tests.Mocks;
    using FurnitureHandbook.Web.ViewModels.Furnitures;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class HardwareServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<Hardware>> mockRepo;
        private readonly HardwareService service;

        public HardwareServiceTests()
        {
            this.mockRepo = HardwareMockRepository.GetHardwareMockRepo();
            this.service = new HardwareService(this.mockRepo.Object);
        }

        [Fact]
        public async Task CreateHardwareTest()
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
                EdgebandId = 1,
                HandleModel = "Извити-кръгообразни",
                MechanismType = "Плавни механизми",
                MechanismQuantity = 5,
                HingeType = "Плавни панти",
                HingeQuantity = 32,
            };

            await this.service.CreateAsync(furnitureModel);

            var count = this.mockRepo.Object.All().Count();
            var handleModelFurniture = this.mockRepo.Object.All().Skip(2).First().HandleModel;
            Assert.Equal("Извити-кръгообразни", handleModelFurniture);

            Assert.True(count == 3);
        }
    }
}
