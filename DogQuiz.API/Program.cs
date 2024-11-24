using Microsoft.EntityFrameworkCore;
using DogQuiz.API.Middleware;
using DogQuiz.Infrastructure;
using DogQuiz.Application.Breeds;
using DogQuiz.Application.Shared.Features;
using DogQuiz.Infrastructure.Initialization;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddProblemDetails();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICreateBreed, CreateBreed>();
builder.Services.AddScoped<IGetCountries, GetCountries>();

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
//builder.Services.AddKeycloakWebApiAuthentication(builder.Configuration);
//builder.Services.AddAuthorization();

//builder.Services.AddCors(options =>
//{
//	options.AddPolicy("AllowFrontend", policy =>
//	{
//		policy.WithOrigins("http://localhost:5001") // need url!
//			  .AllowAnyHeader()
//			  .AllowAnyMethod();
//	});
//});

builder.Services.AddScoped<CountrySeeder>();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;

	try
	{
		var seeder = services.GetRequiredService<CountrySeeder>();
		await seeder.SeedAsync(); // Call the async method
	}
	catch (Exception ex)
	{
		var logger = services.GetRequiredService<ILogger<Program>>();
		logger.LogError(ex, "An error occurred while seeding the database.");
		throw;
	}
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowFrontend");
app.MapControllers();
//app.MapGet("/test.html", () => "Hello World!").RequireAuthorization();
app.MapFallbackToFile("/index.html");
app.MapDefaultEndpoints();

app.Run();