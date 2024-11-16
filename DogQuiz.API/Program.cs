using DogQuiz.API.Services;
using DogQuiz.API.Services.Interfaces;
using DogQuiz.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("db1"), sqlOptions =>
	{
		// Workaround for https://github.com/dotnet/aspire/issues/1023
		sqlOptions.ExecutionStrategy(c => new RetryingSqlServerRetryingExecutionStrategy(c));
	}));
builder.EnrichSqlServerDbContext<ApplicationDbContext>(settings =>
	// Disable Aspire default retries as we're using a custom execution strategy
	settings.DisableRetry = true);

var app = builder.Build();

app.MapDefaultEndpoints();

app.Run();

/* The above configuration is intended to get migrations fully working; *
 * later, switch back to the previous configuration below.				*/

//using DogQuiz.API.Services;
//using DogQuiz.API.Services.Interfaces;
//using DogQuiz.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.FileProviders;

//var builder = WebApplication.CreateBuilder(args);

//builder.AddServiceDefaults();

//builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
//	options.UseSqlServer(builder.Configuration.GetConnectionString("db1"), sqlOptions =>
//	{
//		// Workaround for https://github.com/dotnet/aspire/issues/1023
//		sqlOptions.ExecutionStrategy(c => new RetryingSqlServerRetryingExecutionStrategy(c));
//	}));
//builder.EnrichSqlServerDbContext<ApplicationDbContext>(settings =>
//	// Disable Aspire default retries as we're using a custom execution strategy
//	settings.DisableRetry = true);

//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddAuthorization();
//builder.Services.AddScoped<IBreedService, BreedService>();

//var app = builder.Build();

//app.UseHttpsRedirection();
//app.UseStaticFiles(new StaticFileOptions
//{
//	FileProvider = new PhysicalFileProvider(
//		Path.Combine(Directory.GetCurrentDirectory(), "Images")),
//	RequestPath = "/images"
//});

//if (!app.Environment.IsDevelopment())
//{
//	app.UseExceptionHandler("/Error");
//	app.UseHsts();
//}

//if (app.Environment.IsDevelopment())
//{
//	app.UseSwagger();
//	app.UseSwaggerUI();
//}

//// Routing setup (must be before Authentication and Authorization)
//app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();

////app.MapIdentityApi<User>();
//app.MapControllers();
//app.MapFallbackToFile("/index.html");
//app.MapDefaultEndpoints();

//app.Run();