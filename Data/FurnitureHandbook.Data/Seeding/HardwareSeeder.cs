namespace FurnitureHandbook.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class HardwareSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var hardwaresList = new List<Hardware>()
            {
                new Hardware
                {
                    HandleModel = "Класически дръжки",
                    MechanismType = "Плавни",
                    MechanismQuantity = 5,
                    HingeType = "Плавни",
                    HingeQuantity = 20,
                },
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

            foreach (Hardware hardware in hardwaresList)
            {
                var dbHardware = await dbContext.Hardwares
                    .FirstOrDefaultAsync(x => x.MechanismType == hardware.MechanismType);

                if (dbHardware == null)
                {
                    await dbContext.Hardwares.AddAsync(hardware);
                }
            }
        }
    }
}
