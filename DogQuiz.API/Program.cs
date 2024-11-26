using Microsoft.EntityFrameworkCore;
using DogQuiz.API.Middleware;
using DogQuiz.Infrastructure;
using DogQuiz.Infrastructure.Initialization;
using FluentValidation;
using DogQuiz.API.Validators;
using DogQuiz.Application.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddProblemDetails();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblyContaining<CreateBreedValidator>();

builder.Services.AddApplicationServices();

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

var app = builder.Build();

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