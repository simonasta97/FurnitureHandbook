namespace FurnitureHandbook.Services.Data.Tests.Mocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Common.Repositories;
    using FurnitureHandbook.Data.Models;
    using Moq;

    public class DocumentMockRepository
    {
        public static Mock<IDeletableEntityRepository<Document>> GetDocumentMockRepo()
        {
            var mockRepo = new Mock<IDeletableEntityRepository<Document>>();

            var list = new List<Document>()
            {
                new Document
                {
                    Id = 1,
                    Name = "Празен шаблон на ЦЕНОВА ОФЕРТА",
                    FileUrl = "/documents/Празен шаблон на ЦЕНОВА ОФЕРТА.docx",
                    Size = 57,
                    FileType = FileType.Word,
                    CategoryId = 1,
                    CreatedOn = DateTime.Now,
                },

                new Document
                {
                    Id = 2,
                    Name = "Примерен чертеж на Г-образна кухня",
                    FileUrl = "/documents/Примерен чертеж на Г-образна кухня.jpg",
                    Size = 190,
                    FileType = FileType.Image,
                    CategoryId = 1,
                    CreatedOn = DateTime.Now,
                },
            };

            mockRepo.Setup(r => r.All()).Returns(list.AsQueryable());

            mockRepo.Setup(r => r.AllAsNoTracking()).Returns(list.Where(x => x.IsDeleted == false).AsQueryable());

            mockRepo.Setup(r => r.AllAsNoTrackingWithDeleted()).Returns(list.AsQueryable());

            mockRepo.Setup(r => r.Delete(It.IsAny<Document>()))
                                 .Callback((Document document) => list.Remove(document));
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Document>()))
                                 .Callback((Document document) => list.Add(document));

            return mockRepo;
        }
    }
}
