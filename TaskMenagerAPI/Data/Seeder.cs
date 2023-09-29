using Microsoft.AspNetCore.Identity;
using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Data
{
    public static class Seeder
    {
        public static async Task InInitializerAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminRole = "admin";
            string adminUserName = "admin";
            string adminEmail = "admin@gmail.com";
            string adminPassword = "P@ssw0rd";


            if(!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            if(await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new User
                {
                    UserName = adminUserName,
                    Email = adminEmail,
                    IsActive = true,
                    
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, adminRole);
                }
            } 


        }
    }
}
