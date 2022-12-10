namespace FurnitureHandbook.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Common.Repositories;
    using FurnitureHandbook.Data.Models;
    using FurnitureHandbook.Services.Data.Documents;
    using FurnitureHandbook.Services.Data.Tests.Mocks;
    using FurnitureHandbook.Web.ViewModels.Documents;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class DocumentServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<Document>> mockRepo;
        private readonly DocumentsService service;

        public DocumentServiceTests()
        {
            this.mockRepo = DocumentMockRepository.GetDocumentMockRepo();
            this.service = new DocumentsService(this.mockRepo.Object);
        }

        [Fact]
        public async Task CreateDocumentTest()
        {
            var file = new Mock<IFormFile>();

            var document = new CreateDocumentInputModel
            {
                Name = "Варианти за кухненски барплот",
                Size = 253,
                File = file.Object,
                FileType = "Pdf",
                CategoryId = 1,
            };

            await this.service.CreateAsync(document, "document");

            var count = this.mockRepo.Object.All().Count();
            var name = this.mockRepo.Object.All().Skip(2).First().Name;
            Assert.Equal("Варианти за кухненски барплот", name);

            Assert.True(count == 3);
        }

        [Fact]
        public async Task CreateDocumentExceptionTest()
        {
            var file = new Mock<IFormFile>();

            var document = new CreateDocumentInputModel
            {
                Name = "Примерен чертеж на Г-образна кухня",
                Size = 253,
                File = file.Object,
                FileType = "Pdf",
                CategoryId = 1,
            };

            await Assert.ThrowsAsync<System.Exception>(() => this.service.CreateAsync(document, "document"));
        }

        [Fact]
        public async Task DeleteDocumentTest()
        {
            await this.service.DeleteAsync(1);
            await this.service.DeleteAsync(2);

            var count = this.mockRepo.Object.All().Count();

            Assert.True(count == 0);
        }

        [Fact]
        public async Task DeleteChefExceptionTest()
        {
            await this.service.DeleteAsync(1);
            await this.service.DeleteAsync(2);

            await Assert.ThrowsAsync<System.Exception>(() => this.service.DeleteAsync(1));
        }
    }
}
