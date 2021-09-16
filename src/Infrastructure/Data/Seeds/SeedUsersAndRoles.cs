using Core.Entities.Enums;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seeds
{
    public class SeedUsersAndRoles
    {
        public static async Task SeedUsersAndRolesAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            if (!userManager.Users.Any())
            {
                var rolesFromEnum = Enum.GetValues(typeof(RolesEnum));


                foreach (var role in rolesFromEnum)
                {
                    await roleManager.CreateAsync(new Role { Name = role.ToString() });
                }

                var admin = new User
                {
                    Email = "admin@jarek.pl",
                    UserName = "admin@jarek.pl",
                    FirstName = "admin",
                    LastName = "adminowy"
                };

                var user = new User
                {
                    Email = "user@jarek.pl",
                    UserName = "uuer@jarek.pl",
                    FirstName = "user",
                    LastName = "userowy"
                };

                await userManager.CreateAsync(admin, "Pa$$w0rd");

                await userManager.CreateAsync(user, "Pa$$w0rd");

                await userManager.AddToRoleAsync(admin, RolesEnum.Admin.ToString());
                await userManager.AddToRoleAsync(user, RolesEnum.Member.ToString());
            }
        }
            
    }
}
