namespace FurnitureHandbook.Services.Data.Textures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Web.ViewModels.Furnitures;

    public interface ITexturesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        public Task<int?> CreateAsync(CreateFurnitureInputModel furnitureModel);
    }
}
