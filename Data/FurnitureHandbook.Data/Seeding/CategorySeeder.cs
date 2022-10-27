namespace FurnitureHandbook.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class CategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var categoriesList = new List<Category>()
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

                new Category
                {
                    Name = "Детска стая",
                    ImageUrl = "/images/detska-staq.jpg",
                    Description = "Създайте перфектната детска стая." +
                    "Кои са основните мебели за детски стаи?" +
                    "Какво обзавеждане за детска стая можете да предлолжите?",
                },

                new Category
                {
                    Name = "Коридор",
                    ImageUrl = "/images/antre.jpg",
                    Description = "Коридорът е входът към Всеки дом." +
                    "Какво трябва да знаете за производството и проектирането на портманта?" +
                    "Портмантата са точно това, от което се нуждае всеки коридор.",
                },
            };

            foreach (Category category in categoriesList)
            {
                var dbCategory = await dbContext.Categories
                    .FirstOrDefaultAsync(x => x.Name == category.Name);

                if (dbCategory == null)
                {
                    await dbContext.Categories.AddAsync(category);
                }
            }
        }
    }
}
