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

    public class FurnitureMockRepository
    {
        public static Mock<IDeletableEntityRepository<Furniture>> GetFurnitureMockRepo()
        {
            var mockRepo = new Mock<IDeletableEntityRepository<Furniture>>();

            var list = new List<Furniture>()
            {
               new Furniture
               {
                    Id = 1,
                    Name = "Кухня",
                    ImageUrl = "/images/Atanas-Dimitrov-Kuhnq.jpg",
                    Color = "Сив мат с дъб Кендъл",
                    Length = 438,
                    Depth = 55,
                    Width = 85,
                    TextureId = 6,
                    EdgebandId = 2,
                    HardwareId = 1,
               },
               new Furniture
               {
                    Id = 2,
                    Name = "Барплот",
                    ImageUrl = "/images/Atanas-Dimitrov-barplot.jpg",
                    Color = "Сив мат с дъб Кендъл",
                    Length = 100,
                    Depth = 60,
                    Width = 85,
                    TextureId = 6,
                    EdgebandId = 2,
                    HardwareId = 1,
               },
            };

            mockRepo.Setup(r => r.All()).Returns(list.AsQueryable());

            mockRepo.Setup(r => r.AllAsNoTracking()).Returns(list.Where(x => x.IsDeleted == false).AsQueryable());

            mockRepo.Setup(r => r.AllAsNoTrackingWithDeleted()).Returns(list.AsQueryable());
            mockRepo.Setup(r => r.Delete(It.IsAny<Furniture>()))
                                 .Callback((Furniture furniture) => list.Remove(furniture));
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Furniture>()))
                                 .Callback((Furniture furniture) => list.Add(furniture));

            return mockRepo;
        }
    }
}
