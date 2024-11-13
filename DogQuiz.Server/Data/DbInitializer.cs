using DogQuiz.Server.Models.Auth;
using Microsoft.AspNetCore.Identity;

namespace DogQuiz.Server.Data;

public static class DbInitializer
{
    public static async Task SeedAdminUserAndRole(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        string adminRole = "Admin";

        var adminUserConfig = configuration.GetSection("AdminUser");
        string adminUsername = adminUserConfig["Username"] ?? throw new Exception("Admin username not set in appsettings.Development.json.");
        string adminEmail = adminUserConfig["Email"] ?? throw new Exception("Admin email not set in appsettings.Development.json."); ;
        string adminPassword = adminUserConfig["Password"] ?? throw new Exception("Admin password not set in appsettings.Development.json."); ;

        if (!await roleManager.RoleExistsAsync(adminRole))
        {
            await roleManager.CreateAsync(new IdentityRole(adminRole));
        }

        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            adminUser = new User
            {
                UserName = adminUsername,
                Email = adminEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, adminPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, adminRole);
            }
        }
    }
}