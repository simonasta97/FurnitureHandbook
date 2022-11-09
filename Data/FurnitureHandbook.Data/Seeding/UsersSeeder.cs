namespace FurnitureHandbook.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using static FurnitureHandbook.Common.GlobalConstants;

    public class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            const string adminEmail = "admin@test.test";
            const string AdminPassword = "111111";
            const string UserPassword = "333333";

            var adminUser = new ApplicationUser
            {
                FirstName = "Admin",
                LastName = "Adminov",
                Email = adminEmail,
                UserName = adminEmail,
            };

            await SeedUsersRoles(dbContext, userManager, adminUser, AdminPassword, AdministratorRoleName);

            var applicationUsersList = new List<ApplicationUser>()
                {
                    new ApplicationUser
                    {
                        FirstName = "Martin",
                        LastName = "Milchev",
                        Email = "martin_milchevv@abv.bg",
                        UserName = "martin_milchevv@abv.bg",
                        PhoneNumber = "+359 897744346",
                    },
                };

            foreach (ApplicationUser applicationUser in applicationUsersList)
            {
                await SeedUsersRoles(dbContext, userManager, applicationUser, UserPassword, null);
            }
        }

        private static async Task SeedUsersRoles(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, ApplicationUser user, string password, string roleName)
        {
            var dbApplicationUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == user.Email);

            if (dbApplicationUser == null)
            {
                await userManager.CreateAsync(user, password);

                if (roleName != null)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
    }
}
