using DogQuiz.TempUI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add default services
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorPages();

// Retrieve the API URLs from environment variables
var apiUrlHttp = builder.Configuration.GetValue<string>("API_URL_HTTP");
var apiUrlHttps = builder.Configuration.GetValue<string>("API_URL_HTTPS");

// Determine which API URL to use (prefer HTTPS if available)
var apiUrl = !string.IsNullOrEmpty(apiUrlHttps) ? apiUrlHttps : apiUrlHttp;

if (string.IsNullOrEmpty(apiUrl))
{
	throw new InvalidOperationException("Neither API_URL_HTTP nor API_URL_HTTPS is set in the environment variables.");
}

// Register HttpClient for API communication
builder.Services.AddHttpClient("API", client =>
{
	client.BaseAddress = new Uri(apiUrl);
	client.DefaultRequestHeaders.Add("Accept", "application/json");
});

// Register the API service
builder.Services.AddScoped<ApiService>();

// Add CORS policy
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowFrontend", policy =>
	{
		policy.WithOrigins("http://localhost:5001") // Adjust based on your Razor Pages URL
			  .AllowAnyHeader()
			  .AllowAnyMethod();
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	app.UseHsts(); // Use HTTP Strict Transport Security
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable CORS
app.UseCors("AllowFrontend");

app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

// Middleware to handle unmatched routes and redirect to the API
//app.Use(async (context, next) =>
//{
//	// Redirect all unmatched routes to the API base URL
//	if (!context.Request.Path.StartsWithSegments("/api") &&
//		!System.IO.File.Exists($"wwwroot{context.Request.Path}") &&
//		!context.Request.Path.StartsWithSegments("/"))
//	{
//		context.Response.Redirect(apiUrl + context.Request.Path);
//		return;
//	}
//	await next();
//});

app.Use(async (context, next) =>
{
	// Ignore API and Razor Pages routes
	if (!context.Request.Path.StartsWithSegments("/api") &&
		//!context.Request.Path.StartsWithSegments("/CreateBreed") &&
		//!context.Request.Path.StartsWithSegments("/Privacy") &&
		!System.IO.File.Exists($"wwwroot{context.Request.Path}") &&
		!context.Request.Path.StartsWithSegments("/"))
	{
		context.Response.Redirect(apiUrl + context.Request.Path);
		return;
	}
	await next();
});

// Map Razor Pages
app.MapRazorPages();

app.Run();

#if false

using DogQuiz.TempUI.Services;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add default services
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorPages();

// Retrieve the API URLs from environment variables or configuration
var apiUrls = builder.Configuration.GetSection("API");
var apiUrlHttp = apiUrls["BaseUrlHttp"];
var apiUrlHttps = apiUrls["BaseUrlHttps"];

// Determine which API URL to use (prefer HTTPS if available)
var apiUrl = !string.IsNullOrEmpty(apiUrlHttps) ? apiUrlHttps : apiUrlHttp;

if (string.IsNullOrEmpty(apiUrl))
{
    throw new InvalidOperationException("Neither API BaseUrlHttp nor BaseUrlHttps is set in the configuration.");
}

// Register HttpClient for API communication
builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri(apiUrl);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

// Register the API service
builder.Services.AddScoped<ApiService>();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5001") // Adjust based on your Razor Pages URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add health checks
builder.Services.AddHealthChecks()
    .AddCheck("API Health", () => !string.IsNullOrEmpty(apiUrl)
        ? HealthCheckResult.Healthy("API URL configured")
        : HealthCheckResult.Unhealthy("API URL missing"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Enable CORS
app.UseCors("AllowFrontend");

// Authorization middleware
app.UseAuthorization();

// Custom middleware for unmatched routes
app.UseMiddleware<UnmatchedRouteRedirectMiddleware>(apiUrl);

// Map Razor Pages
app.MapRazorPages();

// Map health check endpoint
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = async (context, report) =>
    {
        context.Response.ContentType = "application/json";
        var result = System.Text.Json.JsonSerializer.Serialize(new
        {
            status = report.Status.ToString(),
            checks = report.Entries.Select(entry => new
            {
                name = entry.Key,
                status = entry.Value.Status.ToString(),
                description = entry.Value.Description
            })
        });
        await context.Response.WriteAsync(result);
    }
});

app.Run();

// Custom middleware for unmatched routes
public class UnmatchedRouteRedirectMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _apiUrl;

    public UnmatchedRouteRedirectMiddleware(RequestDelegate next, string apiUrl)
    {
        _next = next;
        _apiUrl = apiUrl;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Path.StartsWithSegments("/api") &&
            !context.Request.Path.StartsWithSegments("/CreateBreed") &&
            !context.Request.Path.StartsWithSegments("/Privacy") &&
            !System.IO.File.Exists($"wwwroot{context.Request.Path}") &&
            !context.Request.Path.StartsWithSegments("/"))
        {
            context.Response.Redirect(_apiUrl + context.Request.Path);
            return;
        }

        await _next(context);
    }
}


#endif