namespace FurnitureHandbook.Services.Data.Edgebands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Common.Repositories;
    using FurnitureHandbook.Data.Models;

    public class EdgebandsService : IEdgebandsService
    {
        private readonly IDeletableEntityRepository<Edgeband> edgebandsRepository;

        public EdgebandsService(IDeletableEntityRepository<Edgeband> edgebandsRepository)
        {
            this.edgebandsRepository = edgebandsRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.edgebandsRepository
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
