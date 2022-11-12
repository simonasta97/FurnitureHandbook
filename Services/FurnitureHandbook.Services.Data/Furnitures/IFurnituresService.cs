namespace FurnitureHandbook.Services.Data.Furnitures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IFurnituresService
    {
        Task<TModel> GetByIdAsync<TModel>(int id);

        Task DeleteAsync(int id);
    }
}
