using DogQuiz.Data.Entities.Auth;
using Microsoft.Extensions.Configuration;
using System;

namespace DogQuiz.Data.Configurations;

public class DatabaseInitializer
{

    //private readonly ApplicationDbContext _context;
    //private readonly IConfiguration _configuration;

    //public DatabaseInitializer(ApplicationDbContext context, IConfiguration configuration)
    //{
    //    _context = context;
    //    _configuration = configuration;
    //}
    //public async Task SeedAsync()
    //{
    //    if (!_context.Roles.Any())
    //    {
    //        // Define permissions
    //        var permissions = new List<Permission>
    //        {
    //            new Permission { Name = "User.Create", Description = "Create new users", Category = "User Management" },
    //            new Permission { Name = "User.View", Description = "View users", Category = "User Management" },
    //            new Permission { Name = "User.Edit", Description = "Edit existing users", Category = "User Management" },
    //            new Permission { Name = "User.Delete", Description = "Delete users", Category = "User Management" },
    //            new Permission { Name = "PermissionRole.Create", Description = "Create roles", Category = "PermissionRole Management" },
    //            new Permission { Name = "PermissionRole.View", Description = "View roles", Category = "PermissionRole Management" },
    //            new Permission { Name = "PermissionRole.Edit", Description = "Edit roles", Category = "PermissionRole Management" },
    //            new Permission { Name = "PermissionRole.Delete", Description = "Delete roles", Category = "PermissionRole Management" },
    //            new Permission { Name = "Permission.Assign", Description = "Assign permissions to roles", Category = "Permission Management" },
    //            new Permission { Name = "Report.View", Description = "View reports", Category = "Reporting" },
    //            new Permission { Name = "Report.Generate", Description = "Generate new reports", Category = "Reporting" },
    //        };

    //        // Define roles
    //        var adminRole = new PermissionRole
    //        {
    //            Name = "Admin",
    //            Description = "Administrator with full permissions",
    //            Permissions = permissions
    //        };

    //        var userRole = new PermissionRole
    //        {
    //            Name = "User",
    //            Description = "Standard user with limited access",
    //            Permissions = permissions.Where(p => p.Name == "User.View").ToList()
    //        };

    //        // Add roles and permissions to the context
    //        _context.Permissions.AddRange(permissions);
    //        _context.Roles.AddRange(adminRole, userRole);

    //        // Define users
    //        var adminUser = new User
    //        {
    //            IdentityProviderId = _configuration["Admin:IdentityProviderId"] ?? "admin-keycloak-id",
    //            Username = _configuration["Admin:Username"] ?? "admin",
    //            Email = _configuration["Admin:Email"] ?? "admin@example.com",
    //            PermissionRole = adminRole
    //        };

    //        var regularUser = new User
    //        {
    //            IdentityProviderId = "user-keycloak-id",
    //            Username = "user",
    //            Email = "user@example.com",
    //            PermissionRole = userRole
    //        };

    //        // Add users to the context
    //        _context.Users.AddRange(adminUser, regularUser);

    //        // Save changes
    //        await _context.SaveChangesAsync();
    //    }
    //}
}