using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DogQuiz.Server.Data;

public static class MigrationExtensions
{
    /*

    This extension method allows the application to automatically apply database migrations when the application starts,
    which is particularly useful in development or small-scale production environments
    where database schema changes are frequent and managed within the application.

    */

    //public static void ApplyMigrations(this IApplicationBuilder app)
    //{
    //    using IServiceScope scope = app.ApplicationServices.CreateScope();
    //    using ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    //    context.Database.Migrate();
    //}
}
