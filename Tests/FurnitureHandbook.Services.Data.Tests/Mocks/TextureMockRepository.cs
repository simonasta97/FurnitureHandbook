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

    public class TextureMockRepository
    {
        public static Mock<IDeletableEntityRepository<Texture>> GetTextureMockRepo()
        {
            var mockRepo = new Mock<IDeletableEntityRepository<Texture>>();

            var list = new List<Texture>()
            {
                new Texture
                {
                    Name = "АНТИЧНО БЯЛО",
                    Type = TextureType.CHIPBOARD,
                    ManufacturerName = "KASTAMONU",
                    TextureCode = "А428 Frz",
                },
                new Texture
                {
                    Name = "ТЪМНА АНКОНА",
                    Type = TextureType.CHIPBOARD,
                    ManufacturerName = "KASTAMONU",
                    TextureCode = "512 Frz",
                },
            };

            mockRepo.Setup(r => r.All()).Returns(list.AsQueryable());

            mockRepo.Setup(r => r.AllAsNoTracking()).Returns(list.Where(x => x.IsDeleted == false).AsQueryable());

            mockRepo.Setup(r => r.AllAsNoTrackingWithDeleted()).Returns(list.AsQueryable());
            mockRepo.Setup(r => r.Delete(It.IsAny<Texture>()))
                                 .Callback((Texture texture) => list.Remove(texture));
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Texture>()))
                                 .Callback((Texture texture) => list.Add(texture));

            return mockRepo;
        }
    }
}
