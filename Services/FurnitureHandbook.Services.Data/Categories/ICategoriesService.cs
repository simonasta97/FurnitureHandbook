namespace FurnitureHandbook.Services.Data.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        Task<TModel> GetByIdAsync<TModel>(int id);
    }
}
