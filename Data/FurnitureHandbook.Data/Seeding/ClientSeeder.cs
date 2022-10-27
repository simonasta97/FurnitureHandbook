namespace FurnitureHandbook.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ClientSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var clientsList = new List<Client>()
            {
                new Client
                {
                    FullName = "Александра Файн",
                    PhoneNumber = "0893636659",
                    Address = "бул.Коматевско шосе 35 , гр.Пловдив",
                },
                new Client
                {
                    FullName = "Гергана Кирева",
                    PhoneNumber = "0889864840",
                    Address = "ж.к Тракия блок 108 вход Г , гр.Пловдив",
                },
                new Client
                {
                    FullName = "Поля Захариева",
                    PhoneNumber = "0893636659",
                    Address = "ул.Александър Стамболийски 19, гр.Пловдив",
                },
                new Client
                {
                    FullName = "Атанас Димитров",
                    PhoneNumber = "08977400419",
                    Address = "ул.Александър Стамболийски 25, гр.Пловдив",
                },
                new Client
                {
                    FullName = "Габриела Тодорова",
                    PhoneNumber = "0886301790",
                    Address = "ул.Солун 15 ,гр.Първенец",
                },
            };

            foreach (Client client in clientsList)
            {
                var dbClient = await dbContext.Clients
                    .FirstOrDefaultAsync(x => x.FullName == client.FullName);

                if (dbClient == null)
                {
                    await dbContext.Clients.AddAsync(client);
                }
            }
        }
    }
}
