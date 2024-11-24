using DogQuiz.Application.Breeds;
using DogQuiz.Application.Shared.Features;
using Microsoft.Extensions.DependencyInjection;

namespace DogQuiz.Application.Shared;
public static class ServiceRegistrationExtensions
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddScoped<ICreateBreed, CreateBreed>();
		services.AddScoped<IGetCountries, GetCountries>();

		return services;
	}
}
