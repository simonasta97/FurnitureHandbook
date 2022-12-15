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
    using FurnitureHandbook.Services.Data.Furnitures;
    using FurnitureHandbook.Services.Data.Projects;
    using FurnitureHandbook.Services.Data.Tests.Mocks;
    using FurnitureHandbook.Services.Mapping;
    using FurnitureHandbook.Web.ViewModels.Clients;
    using FurnitureHandbook.Web.ViewModels.Documents;
    using FurnitureHandbook.Web.ViewModels.Furnitures;
    using FurnitureHandbook.Web.ViewModels.Projects;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class ProjectServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<Project>> mockRepo;
        private readonly ProjectsService service;

        public ProjectServiceTests()
        {
            this.mockRepo = ProjectMockRepository.GetProjectMockRepo();
            this.service = new ProjectsService(this.mockRepo.Object);
        }

        [Fact]
        public async Task CreateProjectTest()
        {
            var imageProject = new Mock<IFormFile>();

            var projectModel = new CreateProjectInputModel
            {
                Title = "Гардероб с плъзгащи врати",
                CategoryId = 2,
                ClientId = 5,
                Description = "Гардероба е трикрилен, има 2 лоста за закачалки,4 чекмеджета и 10 отделения.",
                Image = imageProject.Object,
                TotalPrice = 2400,
                DownPayment = 1200,
                Status = StatusType.Active,
            };

            await this.service.CreateAsync(projectModel, "images");

            var count = this.mockRepo.Object.All().Count();
            var description = this.mockRepo.Object.All().Skip(2).First().Description;
            Assert.Equal("Гардероба е трикрилен, има 2 лоста за закачалки,4 чекмеджета и 10 отделения.", description);

            Assert.True(count == 3);
        }

        [Fact]
        public async Task CreateProjectExceptionTest()
        {
            var imageProject = new Mock<IFormFile>();

            var projectModel = new CreateProjectInputModel
            {
                Title = "Гардероб с плъзгащи врати",
                CategoryId = 2,
                ClientId = 5,
                Description = "Гардероба е трикрилен, има 2 лоста за закачалки,4 чекмеджета и 10 отделения.",
                Image = imageProject.Object,
                TotalPrice = 2400,
                DownPayment = 1200,
                Status = StatusType.Active,
                EndDate = DateTime.Parse("2021/08/30"),
                StartDate = DateTime.Parse("2021/10/30"),
            };

            await Assert.ThrowsAsync<System.Exception>(() => this.service.CreateAsync(projectModel, "images"));
        }

        [Fact]
        public async Task EditProjectTest()
        {
            var projectModel = new EditProjectInputModel
            {
                Id = "d958d727-ab35-4b8e-9328-63ebc3790498",
                Title = "Кухня,барплот и хладилен шкаф",
                Description = "Кухнята е с Г образна форма, барплота е с едно лице,печка над микровълнова.",
                TotalPrice = 7300,
                DownPayment = 4000,
                Status = StatusType.Completed,
                StartDate = DateTime.Parse("2021/08/30"),
                EndDate = DateTime.Parse("2021/09/30"),
            };

            await this.service.UpdateAsync("d958d727-ab35-4b8e-9328-63ebc3790498", projectModel);
            Assert.Equal(4000, this.mockRepo.Object.All().First().DownPayment);
            Assert.Equal("d958d727-ab35-4b8e-9328-63ebc3790498", this.mockRepo.Object.All().First().Id);
        }

        [Fact]
        public async Task EditProjectExceptionTest()
        {
            var projectModel = new EditProjectInputModel
            {
                Id = "d958d727-ab35-4b8e-9328-63ebc3790498",
                Title = "Кухня,барплот и хладилен шкаф",
                Description = "Кухнята е с Г образна форма, барплота е с едно лице,печка над микровълнова.",
                TotalPrice = 7300,
                DownPayment = 4000,
                Status = StatusType.Completed,
                StartDate = DateTime.Parse("2021/08/30"),
                EndDate = DateTime.Parse("2021/09/30"),
            };

            await Assert.ThrowsAsync<System.NullReferenceException>(() => this.service.UpdateAsync("test", projectModel));
        }

        [Fact]
        public async Task DeleteProjectTest()
        {
            await this.service.DeleteAsync("d958d727-ab35-4b8e-9328-63ebc3790498");
            await this.service.DeleteAsync("71944391-a4ec-4386-85e5-764fa727738e");

            var count = this.mockRepo.Object.All().Count();

            Assert.True(count == 0);
        }

        [Fact]
        public async Task DeleteProjectExceptionTest()
        {
            await this.service.DeleteAsync("d958d727-ab35-4b8e-9328-63ebc3790498");
            await this.service.DeleteAsync("71944391-a4ec-4386-85e5-764fa727738e");

            await Assert.ThrowsAsync<System.Exception>(() => this.service.DeleteAsync("d958d727-ab35-4b8e-9328-63ebc3790498"));
        }

        [Fact]
        public async Task GetCountShouldReturnCorrectNumber()
        {
            await this.service.GetCountAsync();
            Assert.Equal(2, this.service.GetCountAsync().Result);
        }
    }
}
