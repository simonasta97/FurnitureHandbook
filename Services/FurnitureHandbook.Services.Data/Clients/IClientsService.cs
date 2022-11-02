namespace FurnitureHandbook.Services.Data.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Web.ViewModels.Clients;

    public interface IClientsService
    {
        Task CreateAsync(CreateClientInputModel clientModel);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        Task<int> GetCountAsync();
    }
}
