using DogQuiz.Application.Shared.DTOs;
using DogQuiz.Application.Shared.Mappers;
using DogQuiz.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Application.Shared.Features;

public interface IGetCountries
{
	public Task<List<GetCountryDto>> GetCountriesAsync();
}

public class GetCountries : IGetCountries
{
	private readonly ApplicationDbContext _context;

	public GetCountries(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<List<GetCountryDto>> GetCountriesAsync()
	{
		var countries = await _context.Countries.ToListAsync();
		return countries.Select(CountryMapper.ToGetCountryDto).ToList();
	}
}