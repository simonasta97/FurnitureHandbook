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

    public class HardwareMockRepository
    {
        public static Mock<IDeletableEntityRepository<Hardware>> GetHardwareMockRepo()
        {
            var mockRepo = new Mock<IDeletableEntityRepository<Hardware>>();

            var list = new List<Hardware>()
            {
                new Hardware
                {
                    HandleModel = "Класически дръжки",
                    MechanismType = "PUSH",
                    MechanismQuantity = 3,
                    HingeType = "Плавни панти",
                    HingeQuantity = 6,
                },
                new Hardware
                {
                    HandleModel = "Вкопани дръжки",
                    MechanismType = "Обикновени",
                    MechanismQuantity = 3,
                    HingeType = "Плавни панти",
                    HingeQuantity = 12,
                },
            };

            mockRepo.Setup(r => r.All()).Returns(list.AsQueryable());

            mockRepo.Setup(r => r.AllAsNoTracking()).Returns(list.Where(x => x.IsDeleted == false).AsQueryable());

            mockRepo.Setup(r => r.AllAsNoTrackingWithDeleted()).Returns(list.AsQueryable());

            mockRepo.Setup(r => r.Delete(It.IsAny<Hardware>()))
                                 .Callback((Hardware hardware) => list.Remove(hardware));
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Hardware>()))
                                 .Callback((Hardware hardware) => list.Add(hardware));

            return mockRepo;
        }
    }
}
