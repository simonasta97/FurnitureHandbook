using FurnitureHandbook.Data.Common.Repositories;
using FurnitureHandbook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureHandbook.Services.Data.Textures
{
    public class TexturesService : ITexturesService
    {
        private readonly IDeletableEntityRepository<Texture> texturesRepository;

        public TexturesService(IDeletableEntityRepository<Texture> texturesRepository)
        {
            this.texturesRepository = texturesRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.texturesRepository
                .AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Name)
                .ToList()
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
