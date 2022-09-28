using Microsoft.AspNetCore.Identity;
using PersonalWellBeing.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWellBeing.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(PersonalWellBeingContext context, UserManager<User>userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    UserName = "eranda",
                    Email = "eranda@test.com"
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Member");
                var admin = new User
                {
                    UserName = "dalma",
                    Email = "dalma@test.com"
                };
                await userManager.CreateAsync(admin, "Pa$$w0rd");
                await userManager.AddToRolesAsync(admin, new[] { "Member", "Admin" });

            }

        }

    }
}
