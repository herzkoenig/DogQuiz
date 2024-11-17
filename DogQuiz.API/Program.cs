using DogQuiz.API.Services;
using DogQuiz.API.Services.Interfaces;
using DogQuiz.Data;
using Keycloak.AuthServices.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddProblemDetails();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBreedService, BreedService>();

builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("sqldb"), sqlOptions =>
	{
		// Workaround for https://github.com/dotnet/aspire/issues/1023
		sqlOptions.ExecutionStrategy(c => new RetryingSqlServerRetryingExecutionStrategy(c));
	}));
builder.EnrichSqlServerDbContext<ApplicationDbContext>(settings =>
	// Disable Aspire default retries as we're using a custom execution strategy
	settings.DisableRetry = true);

// TODO: Configure Keycloak!
builder.Services.AddKeycloakWebApiAuthentication(builder.Configuration);
builder.Services.AddAuthorization();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();

//app.UseStaticFiles(new StaticFileOptions
//{
//	FileProvider = new PhysicalFileProvider(
//		Path.Combine(Directory.GetCurrentDirectory(), "..", "DogQuiz.Images", "Breeds")),
//	RequestPath = "/images"
//});

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGet("/test.html", () => "Hello World!").RequireAuthorization();
app.MapFallbackToFile("/index.html");
app.MapDefaultEndpoints();

app.Run();