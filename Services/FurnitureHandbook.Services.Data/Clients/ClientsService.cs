namespace FurnitureHandbook.Services.Data.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Common.Repositories;
    using FurnitureHandbook.Data.Models;
    using FurnitureHandbook.Services.Mapping;
    using FurnitureHandbook.Web.ViewModels.Clients;
    using Microsoft.EntityFrameworkCore;

    using static FurnitureHandbook.Common.GlobalConstants.Client;

    public class ClientsService : IClientsService
    {
        private readonly IDeletableEntityRepository<Client> clientsRepository;

        public ClientsService(
            IDeletableEntityRepository<Client> clientsRepository)
        {
            this.clientsRepository = clientsRepository;
        }

        public async Task CreateAsync(CreateClientInputModel clientModel)
        {
            var isExist = this.clientsRepository
                .AllAsNoTracking()
                .Any(x => x.FullName == clientModel.FullName && x.PhoneNumber == clientModel.PhoneNumber);

            if (isExist)
            {
                throw new Exception(ClientAlreadyExist);
            }

            var client = new Client
            {
                FullName = clientModel.FullName,
                PhoneNumber = clientModel.PhoneNumber,
                Address = clientModel.Address,
            };

            await this.clientsRepository.AddAsync(client);
            await this.clientsRepository.SaveChangesAsync();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.clientsRepository
                .AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.FullName,
                })
                .OrderBy(x => x.FullName)
                .ToList()
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.FullName));
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
        => await this.clientsRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .To<TModel>()
                .ToListAsync();

        public async Task<int> GetCountAsync()
           => await this.clientsRepository
               .AllAsNoTracking()
               .CountAsync();
    }
}
