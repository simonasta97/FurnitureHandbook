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
    using FurnitureHandbook.Data.Repositories;
    using FurnitureHandbook.Services.Data.Clients;
    using FurnitureHandbook.Services.Data.Tests.Mocks;
    using FurnitureHandbook.Services.Mapping;
    using FurnitureHandbook.Web.ViewModels.Categories;
    using FurnitureHandbook.Web.ViewModels.Clients;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class ClientServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<Client>> mockRepo;
        private readonly ClientsService service;

        public ClientServiceTests()
        {
            this.mockRepo = ClientMockRepository.GetClientMockRepo();
            this.service = new ClientsService(this.mockRepo.Object);
        }

        [Fact]
        public async Task CreateClientTest()
        {
            var client = new CreateClientInputModel
            {
                FullName = "Симона Милчева",
                PhoneNumber = "0895988888",
                Address = "гр.Пловдив, ул.Славееви гори 19",
            };

            await this.service.CreateAsync(client);

            var count = this.mockRepo.Object.All().Count();
            var name = this.mockRepo.Object.All().Skip(2).First().FullName;
            Assert.Equal("Симона Милчева", name);

            Assert.True(count == 3);
        }

        [Fact]
        public async Task CreateClientExceptionTest()
        {
            var client = new CreateClientInputModel
            {
                FullName = "Александра Файн",
                PhoneNumber = "0893636659",
                Address = "бул.Коматевско шосе 35 , гр.Пловдив",
            };

            await Assert.ThrowsAsync<System.Exception>(() => this.service.CreateAsync(client));
        }

        [Fact]
        public async Task GetCountShouldReturnCorrectNumber()
        {
            await this.service.GetCountAsync();
            Assert.Equal(2, this.service.GetCountAsync().Result);
        }

        [Fact]
        public async Task GetAllShouldReturnsAllListWithClients()
        {
            AutoMapperConfig.RegisterMappings(Assembly.Load("FurnitureHandbook.Web.ViewModels"));
            var result = await this.service.GetAllAsync<ClientViewModel>();
            Assert.Equal(2, result.Count());
            Assert.Equal("Александра Файн", result.Where(x => x.FullName == "Александра Файн").Select(x => x.FullName).FirstOrDefault());
        }
    }
}
