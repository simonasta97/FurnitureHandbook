namespace FurnitureHandbook.Services.Data.Furnitures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FurnitureHandbook.Web.ViewModels.Furnitures;
    using FurnitureHandbook.Web.ViewModels.Projects;

    public interface IFurnituresService
    {
        Task CreateAsync(CreateFurnitureInputModel furnitureModel, string pathToSaveInDb);

        Task<TModel> GetByIdAsync<TModel>(int id);

        Task DeleteAsync(int id);
    }
}
