namespace FurnitureHandbook.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class EdgebandSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var edgebandsList = new List<Edgeband>()
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
                new Edgeband
                {
                    Name = "Сиво хром гланц",
                    Thickness = 1.0,
                    ManufacturerName = "AGT",
                },
                new Edgeband
                {
                    Name = "Алпи Фрез",
                    Thickness = 0.5,
                    ManufacturerName = "KRONOSPAN",
                },
                new Edgeband
                {
                    Name = "Капучино мат",
                    Thickness = 1.0,
                    ManufacturerName = "AGT",
                },
            };

            foreach (Edgeband edgeband in edgebandsList)
            {
                var dbEdgeband = await dbContext.Edgebands
                    .FirstOrDefaultAsync(x => x.Name == edgeband.Name);

                if (dbEdgeband == null)
                {
                    await dbContext.Edgebands.AddAsync(edgeband);
                }
            }
        }
    }
}
