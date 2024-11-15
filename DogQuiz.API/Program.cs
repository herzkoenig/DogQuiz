using DogQuiz.API.Data;
using DogQuiz.API.Services;
using DogQuiz.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;
builder.AddSqlServerClient("sqldb");

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//options.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly)));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer("sqldb"));

builder.Services.AddAuthorization();

builder.Services.AddScoped<IBreedService, BreedService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;

	// Automatically apply migrations for ApplicationDbContext
	var appDbContext = services.GetRequiredService<ApplicationDbContext>();

	// Seed initial data for ApplicationDbContext in development
	if (app.Environment.IsDevelopment())
	{
		appDbContext.Database.EnsureDeleted();
		appDbContext.Database.EnsureCreated();
	}
	// Seed admin user and role regardless of environment
	//await DbInitializer.SeedAdminUserAndRole(services, builder.Configuration);
}

app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
	FileProvider = new PhysicalFileProvider(
		Path.Combine(Directory.GetCurrentDirectory(), "Images")),
	RequestPath = "/images"
});

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

// Routing setup (must be before Authentication and Authorization)
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.MapIdentityApi<User>();
app.MapControllers();
app.MapFallbackToFile("/index.html");

app.Run();
