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

    public class CategoryMockRepository
    {
        public static Mock<IDeletableEntityRepository<Category>> GetCategoryMockRepo()
        {
            var mockRepo = new Mock<IDeletableEntityRepository<Category>>();

            var list = new List<Category>()
            {
                new Category
                {
                    Name = "Кухня",
                    ImageUrl = "/images/kuhnq.jpg",
                    Description = "Какво трябва да знаете при избора на обзавеждане за кухни?" +
                    "Започнете да проектирате кухня още ДНЕС с помощта на FURNITURE HANDBOOK!" +
                    "Станете Лидер в производството на кухни!",
                },

                new Category
                {
                    Name = "Спалня",
                    ImageUrl = "/images/spalnq.jpg",
                    Description = "Какво трябва да знаете за обзавеждане на всяка една спалня?" +
                    "Как да проектирате най-подходящите спални комплекти за своите клиенти?" +
                    "В тази категория можете да прочетете незаменими съвети как да създадете мечната СПАЛНЯ!.",
                },
            };

            mockRepo.Setup(r => r.All()).Returns(list.AsQueryable());

            mockRepo.Setup(r => r.AllAsNoTracking()).Returns(list.Where(x => x.IsDeleted == false).AsQueryable().BuildMock());

            mockRepo.Setup(r => r.AllAsNoTrackingWithDeleted()).Returns(list.AsQueryable());

            return mockRepo;
        }
    }
}
