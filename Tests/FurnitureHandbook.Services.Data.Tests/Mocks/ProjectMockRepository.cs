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

    public class ProjectMockRepository
    {
        public static Mock<IDeletableEntityRepository<Project>> GetProjectMockRepo()
        {
            var mockRepo = new Mock<IDeletableEntityRepository<Project>>();

            var list = new List<Project>()
            {
               new Project
               {
                    Id = "d958d727-ab35-4b8e-9328-63ebc3790498",
                    Title = "Кухня,барплот и хладилен шкаф",
                    CategoryId = 1,
                    ClientId = 4,
                    Description = "Кухнята е с Г образна форма, барплота е с едно лице,печка над микровълнова.",
                    ImageUrl = "/images/Proekt-Atanas-Dimitrov.jpg",
                    TotalPrice = 7300,
                    DownPayment = 3400,
                    Status = StatusType.Completed,
                    StartDate = DateTime.Parse("2021/08/30"),
                    EndDate = DateTime.Parse("2021/10/30"),
               },
               new Project
               {
                    Id = "71944391-a4ec-4386-85e5-764fa727738e",
                    Title = "Портманто",
                    CategoryId = 4,
                    ClientId = 1,
                    Description = "Портмантото е с гардероб,модела е изцяло по идея на клиента.",
                    ImageUrl = "/images/Proekt-Aleksandra-Fayn-Portmanto.jpg",
                    TotalPrice = 1310,
                    DownPayment = 500,
                    Status = StatusType.Active,
               },
            };

            mockRepo.Setup(r => r.All()).Returns(list.AsQueryable());

            mockRepo.Setup(r => r.AllAsNoTracking()).Returns(list.Where(x => x.IsDeleted == false).AsQueryable());

            mockRepo.Setup(r => r.AllAsNoTrackingWithDeleted()).Returns(list.AsQueryable());
            mockRepo.Setup(r => r.Delete(It.IsAny<Project>()))
                                 .Callback((Project project) => list.Remove(project));
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Project>()))
                                 .Callback((Project project) => list.Add(project));

            return mockRepo;
        }
    }
}
