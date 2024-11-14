using DogQuiz.Server.Configuration;
using DogQuiz.Server.Data;
using DogQuiz.Server.Models.Entities.Auth;
using DogQuiz.Server.Services;
using DogQuiz.Server.Services.Interfaces;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;

builder.Services.AddIdentityServer()
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
            sql => sql.MigrationsAssembly(migrationsAssembly));
    })
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
            sql => sql.MigrationsAssembly(migrationsAssembly));
    })
    .AddAspNetIdentity<User>();

builder.Services.AddAuthorization();

builder.Services.AddSingleton<IEmailSender<User>, ConsoleEmailSender>();
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
        //appDbContext.Database.EnsureDeleted();
        //appDbContext.Database.EnsureCreated();

        // Seed initial data
        var dataInitializer = new CreateDummyData(appDbContext);
        dataInitializer.CreateData();
    }

    var configDbContext = services.GetRequiredService<ConfigurationDbContext>();

    // Seed IdentityServer configuration
    IdentityServerSeeder.SeedIdentityServerConfig(configDbContext);

    // Seed admin user and role regardless of environment
    await DbInitializer.SeedAdminUserAndRole(services, builder.Configuration);
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

app.MapIdentityApi<User>();
app.MapControllers();
app.MapFallbackToFile("/index.html");

app.Run();
