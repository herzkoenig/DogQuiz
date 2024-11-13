using DogQuiz.Server.Data;
using DogQuiz.Server.Models;
using DogQuiz.Server.Models.Auth;
using DogQuiz.Server.Services;
using DogQuiz.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IBreedService, BreedService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddAuthorization();


// Configures ASP.NET Identity's cookie-based authentication scheme for user sessions
//builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

/* Sets up Identity with 'User' model and 'ApplicationDbContext', creating tables for user authentication. */
//builder.Services.AddIdentityCore<User>()
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddApiEndpoints();

// Configures a generic cookie-based authentication scheme (not tied to ASP.NET Identity)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApplicationDbContext>();
    if (app.Environment.IsDevelopment())
    {
        /* DIRTY HACK for early stages of development!
           Using this to reset the database on startup and seed initial data */
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var dataInitializer = new CreateDummyData(context);
        dataInitializer.CreateData();
    }
    else
    {
        context.Database.Migrate();
    }

    await DbInitializer.SeedAdminUserAndRole(services, builder.Configuration);
}

// Middleware configuration
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

    // Uncomment if migration application is needed at runtime
    // app.ApplyMigrations();
}

// Authentication and Authorization; use after app.UseRouting and before upp.UseEndpoints
app.UseAuthentication();
app.UseAuthorization();

// Endpoint mapping
//app.MapIdentityApi<User>(); // Maps the Endpoints created through .AddEntityFrameworkStores<ApplicationDbContext>()
app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
