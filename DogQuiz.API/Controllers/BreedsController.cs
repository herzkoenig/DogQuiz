using DogQuiz.Application.Breeds.DTOs;
using DogQuiz.Application.Breeds;
using Microsoft.AspNetCore.Mvc;
using DogQuiz.Application.Shared.DTOs;

namespace DogQuiz.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BreedsController : ControllerBase
{
	private readonly ICreateBreed _createBreedService;

	public BreedsController(ICreateBreed createBreedService)
	{
		_createBreedService = createBreedService;
	}

	[HttpPost]
	public async Task<IActionResult> CreateBreed([FromBody] CreateBreedDto createBreedDto)
	{
		if (createBreedDto == null)
		{
			return BadRequest("Breed data is required.");
		}

		try
		{
			// Create the breed
			var createdBreed = await _createBreedService.CreateBreedAsync(createBreedDto);

			// Map to GetBreedDto
			var resultDto = BreedMapper.ToGetBreedDto(createdBreed);

			// Return the created breed DTO with a 201 status code
			return CreatedAtAction(nameof(GetBreedById), new { id = createdBreed.Id }, resultDto);
		}
		catch (Exception ex)
		{
			return StatusCode(500, $"Internal server error: {ex.Message}");
		}
	}

	[HttpGet("{id}")]
	public IActionResult GetBreedById(int id)
	{
		// Placeholder for getting a breed by ID
		return Ok(new { id });
	}
}
