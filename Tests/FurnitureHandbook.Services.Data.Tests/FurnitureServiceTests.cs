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
    using FurnitureHandbook.Services.Data.Furnitures;
    using FurnitureHandbook.Services.Data.Tests.Mocks;
    using FurnitureHandbook.Web.ViewModels.Furnitures;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class FurnitureServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<Furniture>> mockRepo;
        private readonly FurnituresService service;

        public FurnitureServiceTests()
        {
            this.mockRepo = FurnitureMockRepository.GetFurnitureMockRepo();
            this.service = new FurnituresService(this.mockRepo.Object);
        }

        [Fact]
        public async Task CreateFurnitureTest()
        {
            var imageFurniture = new Mock<IFormFile>();

            var furnitureModel = new CreateFurnitureInputModel
            {
                Name = "Хладилен шкаф",
                Image = imageFurniture.Object,
                Color = "Сив мат с дъб Кендъл",
                Length = 438,
                Depth = 55,
                Width = 85,
                TextureId = 6,
                EdgebandId = 2,
                HardwareId = 1,
            };

            await this.service.CreateAsync(furnitureModel, "images");

            var count = this.mockRepo.Object.All().Count();
            var name = this.mockRepo.Object.All().Skip(2).First().Name;
            Assert.Equal("Хладилен шкаф", name);

            Assert.True(count == 3);
        }

        [Fact]
        public async Task DeleteFurnitureTest()
        {
            await this.service.DeleteAsync(1);
            await this.service.DeleteAsync(2);

            var count = this.mockRepo.Object.All().Count();

            Assert.True(count == 0);
        }

        [Fact]
        public async Task DeleteFurnitureExceptionTest()
        {
            await this.service.DeleteAsync(1);
            await this.service.DeleteAsync(2);

            await Assert.ThrowsAsync<System.Exception>(() => this.service.DeleteAsync(1));
        }
    }
}
