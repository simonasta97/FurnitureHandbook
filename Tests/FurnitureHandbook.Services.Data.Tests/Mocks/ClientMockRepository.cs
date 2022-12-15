namespace FurnitureHandbook.Services.Data.Tests.Mocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Common.Repositories;
    using FurnitureHandbook.Data.Models;
    using MockQueryable.Moq;
    using Moq;

    public class ClientMockRepository
    {
        public static Mock<IDeletableEntityRepository<Client>> GetClientMockRepo()
        {
            var mockRepo = new Mock<IDeletableEntityRepository<Client>>();

            var list = new List<Client>()
            {
                new Client
                {
                    FullName = "Александра Файн",
                    PhoneNumber = "0893636659",
                    Address = "бул.Коматевско шосе 35 , гр.Пловдив",
                },
                new Client
                {
                    FullName = "Гергана Кирева",
                    PhoneNumber = "0889864840",
                    Address = "ж.к Тракия блок 108 вход Г , гр.Пловдив",
                },
            };

            mockRepo.Setup(r => r.All()).Returns(list.AsQueryable());

            mockRepo.Setup(r => r.AllAsNoTracking()).Returns(list.Where(x => x.IsDeleted == false).AsQueryable().BuildMock());

            mockRepo.Setup(r => r.AllAsNoTrackingWithDeleted()).Returns(list.AsQueryable());

            mockRepo.Setup(r => r.Delete(It.IsAny<Client>()))
                                 .Callback((Client client) => list.Remove(client));
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Client>()))
                                 .Callback((Client client) => list.Add(client));

            return mockRepo;
        }
    }
}
