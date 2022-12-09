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

    public class EdgebandMockRepository
    {
        public static Mock<IDeletableEntityRepository<Edgeband>> GetEdgebandMockRepo()
        {
            var mockRepo = new Mock<IDeletableEntityRepository<Edgeband>>();

            var list = new List<Edgeband>()
            {
                new Edgeband
                {
                    Name = "Бяло гладко",
                    Thickness = 0.8,
                    ManufacturerName = "ROSI",
                },
                new Edgeband
                {
                    Name = "Гранитно сиво Supramat",
                    Thickness = 1.0,
                    ManufacturerName = "AGT",
                },
            };

            mockRepo.Setup(r => r.All()).Returns(list.AsQueryable());

            mockRepo.Setup(r => r.AllAsNoTracking()).Returns(list.Where(x => x.IsDeleted == false).AsQueryable());

            mockRepo.Setup(r => r.AllAsNoTrackingWithDeleted()).Returns(list.AsQueryable());

            mockRepo.Setup(r => r.Delete(It.IsAny<Edgeband>()))
                                 .Callback((Edgeband edgeband) => list.Remove(edgeband));
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Edgeband>()))
                                 .Callback((Edgeband edgeband) => list.Add(edgeband));

            return mockRepo;
        }
    }
}
