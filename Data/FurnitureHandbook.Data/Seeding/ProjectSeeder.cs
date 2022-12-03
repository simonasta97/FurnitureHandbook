namespace FurnitureHandbook.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Models;
    using Microsoft.EntityFrameworkCore;

    using Furniture = FurnitureHandbook.Data.Models.Furniture;
    using Project = FurnitureHandbook.Data.Models.Project;

    public class ProjectSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var projectsList = new List<Project>()
            {
                new Project
                {
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
                    Furnitures = new List<Furniture>()
                    {
                       new Furniture
                       {
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
                       new Furniture
                       {
                            Name = "Хладилен шкаф",
                            ImageUrl = "/images/Atanas-Dimitrov-hladilen-shkaf.jpg",
                            Color = "Сив мат с дъб Кендъл",
                            Length = 135,
                            Depth = 65,
                            Width = 240,
                            TextureId = 6,
                            EdgebandId = 3,
                            HardwareId = 1,
                       },
                    },
                },
                new Project
                {
                    Title = "Портманто",
                    CategoryId = 4,
                    ClientId = 1,
                    Description = "Портмантото е с гардероб,модела е изцяло по идея на клиента.",
                    ImageUrl = "/images/Proekt-Aleksandra-Fayn-Portmanto.jpg",
                    TotalPrice = 1310,
                    DownPayment = 500,
                    Status = StatusType.Active,
                    Furnitures = new List<Furniture>()
                    {
                        new Furniture
                        {
                            Name = "Портманто",
                            ImageUrl = "/images/Alexandra-Fayn-Antre.jpg",
                            Color = "Карамел",
                            Length = 175,
                            Depth = 40,
                            Width = 240,
                            TextureId = 3,
                            EdgebandId = 5,
                            HardwareId = 2,
                        },
                    },
                },
                new Project
                {
                    Title = "Гардероб с плъзгащи врати",
                    CategoryId = 2,
                    ClientId = 5,
                    Description = "Гардероба е трикрилен, има 2 лоста за закачалки,4 чекмеджета и 10 отделения.",
                    ImageUrl = "/images/Proekt-Gabriela-Todorova.jpg",
                    TotalPrice = 2400,
                    DownPayment = 1200,
                    Status = StatusType.Active,
                    Furnitures = new List<Furniture>()
                    {
                        new Furniture
                        {
                            Name = "Гардероб",
                            ImageUrl = "/images/Gabriela-Todorova-garderob.jpg",
                            Color = "Бяло",
                            Length = 256,
                            Depth = 65,
                            Width = 240,
                            TextureId = 1,
                            EdgebandId = 1,
                            HardwareId = 3,
                        },
                    },
                },
                new Project
                {
                    Title = "Кухня",
                    CategoryId = 1,
                    ClientId = 2,
                    Description = "Над хладнилника ще има шкаф,както и шкаф за бутилки, необходимо е да се скрият няколко тръби отдясно на кухнята при монтаж.",
                    ImageUrl = "/images/Proekt-Gergana-Kireva.jpg",
                    TotalPrice = 3980,
                    DownPayment = 1800,
                    Status = StatusType.Completed,
                    Furnitures = new List<Furniture>()
                    {
                        new Furniture
                        {
                            Name = "Кухня",
                            ImageUrl = "/images/Gergana-Kireva-kuhnq.jpg",
                            Color = "Дъб",
                            Length = 500,
                            Depth = 65,
                            Width = 70,
                            TextureId = 4,
                            EdgebandId = 4,
                            HardwareId = 1,
                        },
                    },
                },
                new Project
                {
                    Title = "Кухня",
                    CategoryId = 1,
                    ClientId = 3,
                    Description = "Кантиране и разкрой на плочите на кухнята ще се направят в Съливер,поради натовареност.",
                    ImageUrl = "/images/Proekt-Polq-Zaharieva.jpg",
                    TotalPrice = 3290,
                    DownPayment = 1600,
                    Status = StatusType.Cancelled,
                },
            };

            foreach (Project project in projectsList)
            {
                var dbProject = await dbContext.Projects
                    .FirstOrDefaultAsync(x => x.Title == project.Title);

                if (dbProject == null)
                {
                    await dbContext.Projects.AddAsync(project);
                }
            }
        }
    }
}
