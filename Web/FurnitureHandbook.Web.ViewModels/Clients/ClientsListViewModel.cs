namespace FurnitureHandbook.Web.ViewModels.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Models;
    using FurnitureHandbook.Services.Mapping;

    public class ClientsListViewModel : IMapFrom<Client>
    {
        public IEnumerable<ClientViewModel> Clients { get; set; }
    }
}
