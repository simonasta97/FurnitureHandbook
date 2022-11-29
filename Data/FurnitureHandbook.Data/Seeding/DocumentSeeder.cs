namespace FurnitureHandbook.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class DocumentSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var documentsList = new List<Document>()
            {
                new Document
                {
                    Name = "Празен шаблон на ЦЕНОВА ОФЕРТА",
                    FileUrl = "/documents/Празен шаблон на ЦЕНОВА ОФЕРТА.docx",
                    Size = 57,
                    FileType = FileType.Word,
                    CategoryId = 1,
                },

                new Document
                {
                    Name = "Примерен чертеж на Г-образна кухня",
                    FileUrl = "/documents/Примерен чертеж на Г-образна кухня.jpg",
                    Size = 190,
                    FileType = FileType.Image,
                    CategoryId = 1,
                },
                new Document
                {
                    Name = "Идеен проект за детска стая - момче",
                    FileUrl = "/documents/Идеен проект за Детска стая_1.pdf",
                    Size = 723,
                    FileType = FileType.Pdf,
                    CategoryId = 3,
                },
                new Document
                {
                    Name = "Идеен проект за детска стая - момиче",
                    FileUrl = "/documents/Детска стая-лилаво с проект.pdf",
                    Size = 144,
                    FileType = FileType.Pdf,
                    CategoryId = 3,
                },
                new Document
                {
                    Name = "Стандарти за обзавеждане на детска стая",
                    FileUrl = "/documents/Стандарти за обзавеждане на детска стая.docx",
                    Size = 367,
                    FileType = FileType.Word,
                    CategoryId = 3,
                },
            };

            foreach (Document document in documentsList)
            {
                var dbDocument = await dbContext.Documents
                    .FirstOrDefaultAsync(x => x.Name == document.Name);

                if (dbDocument == null)
                {
                    await dbContext.Documents.AddAsync(document);
                }
            }
        }
    }
}
