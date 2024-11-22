using System.Net;
using System.Text.Json;

namespace DogQuiz.API.Middleware;

public class ExceptionHandlingMiddleware
{
	private readonly RequestDelegate _next;
	private readonly IWebHostEnvironment _env;
	private readonly ILogger<ExceptionHandlingMiddleware> _logger;

	public ExceptionHandlingMiddleware(RequestDelegate next, IWebHostEnvironment env, ILogger<ExceptionHandlingMiddleware> logger)
	{
		_next = next;
		_env = env;
		_logger = logger;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "An exception occurred while processing the request.");
			await HandleExceptionAsync(context, ex);
		}
	}

	private Task HandleExceptionAsync(HttpContext context, Exception exception)
	{
		context.Response.ContentType = "application/json";

		var statusCode = HttpStatusCode.InternalServerError;
		var response = new
		{
			StatusCode = (int)statusCode,
			Message = "An unexpected error occurred. Please try again later.",
			Details = _env.IsDevelopment() ? exception.Message : null // Always include Details field
		};

		if (exception is UnauthorizedAccessException)
		{
			statusCode = HttpStatusCode.Unauthorized;
			response = new
			{
				StatusCode = (int)statusCode,
				Message = "Access is denied.",
				Details = _env.IsDevelopment() ? exception.Message : null // Include Details field here too
			};
		}
		else if (exception is ArgumentException)
		{
			statusCode = HttpStatusCode.BadRequest;
			response = new
			{
				StatusCode = (int)statusCode,
				Message = exception.Message,
				Details = _env.IsDevelopment() ? exception.Message : null // Include Details field here too
			};
		}
		else if (exception is KeyNotFoundException)
		{
			statusCode = HttpStatusCode.NotFound;
			response = new
			{
				StatusCode = (int)statusCode,
				Message = "The requested resource was not found.",
				Details = _env.IsDevelopment() ? exception.Message : null // Include Details field here too
			};
		}

		context.Response.StatusCode = (int)statusCode;
		return context.Response.WriteAsync(JsonSerializer.Serialize(response));
	}
}
