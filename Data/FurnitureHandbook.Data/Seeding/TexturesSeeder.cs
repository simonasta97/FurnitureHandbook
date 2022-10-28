namespace FurnitureHandbook.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class TexturesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var texturesList = new List<Texture>()
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
                new Texture
                {
                    Name = "Глосмакс ГАЛАКСИ КАРАМЕЛ",
                    Type = TextureType.MDF,
                    ManufacturerName = "GLOSSMAX",
                    TextureCode = "159",
                },
                new Texture
                {
                    Name = "СВЕТЪЛ ДЪБ СОНОМА",
                    Type = TextureType.CHIPBOARD,
                    ManufacturerName = " KRONOSPAN",
                    TextureCode = "3025 SN",
                },
                new Texture
                {
                    Name = "Акрил МАТ ЛАТЕ",
                    Type = TextureType.MDF,
                    ManufacturerName = "KRONOSPAN GL",
                    TextureCode = "7166 АМ",
                },
                new Texture
                {
                    Name = "ГРАФИТ МАТ",
                    Type = TextureType.MDF,
                    ManufacturerName = "KRONOSPAN GL",
                    TextureCode = "FDP2 3355 SM",
                },
            };

            foreach (Texture texture in texturesList)
            {
                var dbTexture = await dbContext.Textures
                    .FirstOrDefaultAsync(x => x.Name == texture.Name);

                if (dbTexture == null)
                {
                    await dbContext.Textures.AddAsync(texture);
                }
            }
        }
    }
}
