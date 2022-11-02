namespace FurnitureHandbook.Web.ViewModels.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Models;
    using FurnitureHandbook.Services.Mapping;

    public class ClientViewModel : IMapFrom<Client>
    {
        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }
}
