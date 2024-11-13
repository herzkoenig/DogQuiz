using DogQuiz.Server.Data;
using DogQuiz.Server.Models.Auth;
using DogQuiz.Server.Services;
using DogQuiz.Server.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

// Configure Identity with User and Role, as well as token providers
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization();

// TODO: Make it a non-generic IEmailSender; see why the Exception was thrown!
builder.Services.AddSingleton<IEmailSender<User>, DogQuiz.Server.Services.NoOpEmailSender>();
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
    var context = services.GetRequiredService<ApplicationDbContext>();

    if (app.Environment.IsDevelopment())
    {
        // Reset database on startup in development only (use for beginning stages of development)
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        // Seed initial data for development
        var dataInitializer = new CreateDummyData(context);
        dataInitializer.CreateData();
    }
    else
    {
        app.ApplyMigrations();
    }

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
