namespace FurnitureHandbook.Services.Data.Edgebands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Web.ViewModels.Furnitures;

    public interface IEdgebandsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        public Task<int?> CreateAsync(CreateFurnitureInputModel furnitureModel);
    }
}
