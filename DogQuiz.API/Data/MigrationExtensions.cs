using Microsoft.EntityFrameworkCore;

namespace DogQuiz.API.Data;

public static class MigrationExtensions
{
	/*

    This extension method allows the application to automatically apply database migrations when the application starts,
    which is particularly useful in development or small-scale production environments
    where database schema changes are frequent and managed within the application.

    */

	public static void ApplyMigrations(this IApplicationBuilder app)
	{
		using var scope = app.ApplicationServices.CreateScope();
		var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

		try
		{
			context.Database.Migrate();
			Console.WriteLine("Database migrations applied successfully.");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error applying database migrations: {ex.Message}");
			// Log the error, alert monitoring services, etc.
		}
	}

}
