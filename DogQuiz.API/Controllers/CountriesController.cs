using Microsoft.AspNetCore.Mvc;
using DogQuiz.Application.Shared.Features;

namespace DogQuiz.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
	private readonly IGetCountries _getCountriesService;

	public CountriesController(IGetCountries getCountriesService)
	{
		_getCountriesService = getCountriesService;
	}

	[HttpGet]
	public async Task<IActionResult> GetCountries()
	{
		try
		{
			var countries = await _getCountriesService.GetCountriesAsync();
			return Ok(countries);
		}
		catch (Exception ex)
		{
			return StatusCode(500, "An error occurred while fetching countries.");
		}
	}
}