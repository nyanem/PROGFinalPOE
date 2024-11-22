using Microsoft.AspNetCore.Identity;

namespace PROGFinalPOE.Data
{
    public class DatabaseSeeder
    {
        public static async Task SeedRolesAndUsers(IServiceProvider serviceProvider)
        {
            // Retrieve RoleManager and UserManager from DI container
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Define roles to seed
            string[] roles = { "Admin", "Lecturer" };

            // Ensure all roles exist
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            // Seed Admin user
            var adminUser = new IdentityUser
            {
                UserName = "admin@cmcs.com",
                Email = "admin@cmcs.com"
            };

            if (userManager.Users.All(u => u.UserName != adminUser.UserName))
            {
                var result = await userManager.CreateAsync(adminUser, "Admin@123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
            var lecturerUser = new IdentityUser
            {
                UserName = "lecturer@cmcs.com",
                Email = "lecturer@cmcs.com"
            };

            if (userManager.Users.All(u => u.UserName != lecturerUser.UserName))
            {
                var result = await userManager.CreateAsync(lecturerUser, "Lecturer@123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(lecturerUser, "Lecturer");
                }
            }
        }
    }
}
