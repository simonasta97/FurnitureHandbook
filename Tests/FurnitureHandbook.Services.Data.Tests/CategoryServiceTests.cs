namespace FurnitureHandbook.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Common.Repositories;
    using FurnitureHandbook.Data.Models;
    using FurnitureHandbook.Services.Data.Categories;
    using FurnitureHandbook.Services.Data.Clients;
    using FurnitureHandbook.Services.Data.Tests.Mocks;
    using FurnitureHandbook.Services.Mapping;
    using FurnitureHandbook.Web.ViewModels.Categories;
    using FurnitureHandbook.Web.ViewModels.Clients;
    using Moq;
    using Xunit;

    public class CategoryServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<Category>> mockRepo;
        private readonly CategoriesService service;

        public CategoryServiceTests()
        {
            this.mockRepo = CategoryMockRepository.GetCategoryMockRepo();
            this.service = new CategoriesService(this.mockRepo.Object);
        }

        [Fact]
        public async Task GetAllShouldReturnsAllListWithCategories()
        {
            AutoMapperConfig.RegisterMappings(Assembly.Load("FurnitureHandbook.Web.ViewModels"));
            var result = await this.service.GetAllAsync<CategoryViewModel>();
            Assert.Equal(2, result.Count());
            Assert.Equal("Кухня", result.Where(x => x.Name == "Кухня").Select(x => x.Name).FirstOrDefault());
            Assert.Equal("/images/spalnq.jpg", result.Where(x => x.Name == "Спалня").Select(x => x.ImageUrl).FirstOrDefault());
        }
    }
}
