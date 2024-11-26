using Microsoft.AspNetCore.Mvc;
using DogQuiz.Application.Shared.Features;

namespace DogQuiz.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
	private readonly IGetCountries _getCountries;

	public CountriesController(IGetCountries getCountries)
	{
		_getCountries = getCountries;
	}

	[HttpGet]
	public async Task<IActionResult> GetCountries()
	{
		var countries = await _getCountries.GetCountriesAsync();
		return Ok(countries);
	}
}