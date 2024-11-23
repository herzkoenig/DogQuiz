﻿using DogQuiz.API.Requests;
using DogQuiz.Application.Breeds.CreateBreedFact;
using DogQuiz.Domain.Breeds.Validation;
using DogQuiz.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace DogQuiz.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BreedsController : ControllerBase
{
	private readonly ApplicationDbContext _context;
	private readonly IBreedService _breedService;
	private readonly IBreedFactGeneratorService _breedFactGeneratorService;

	public BreedsController(
		 ApplicationDbContext context,
		 IBreedService breedService,
		 IBreedFactGeneratorService breedFactGeneratorService)
	{
		_context = context;
		_breedService = breedService;
		_breedFactGeneratorService = breedFactGeneratorService;
	}

	[HttpPost]
	public async Task<IActionResult> CreateBreed([FromBody] CreateBreedRequest request)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		// Map the request to the Breed entity
		var breed = request.ToBreed();

		// Save the new breed using the service
		var createdBreed = await _breedService.CreateBreedAsync(breed);

		return CreatedAtAction(nameof(GetBreed), new { id = createdBreed.Id }, createdBreed);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateBreed(int id, [FromBody] UpdateBreedRequest request)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		var existingBreed = await _breedService.GetBreedByIdAsync(id);
		if (existingBreed == null)
			return NotFound();

		// Map the request to the existing Breed entity
		request.UpdateBreedFromRequest(existingBreed);

		// Update the breed using the service
		var updatedBreed = await _breedService.UpdateBreedAsync(existingBreed);

		return Ok(updatedBreed);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetBreed(int id)
	{
		var breed = await _breedService.GetBreedByIdAsync(id);
		if (breed == null)
			return NotFound();

		return Ok(breed);
	}

	[HttpGet]
	public async Task<IActionResult> GetAllBreeds()
	{
		var breeds = await _breedService.GetAllBreedsAsync();
		return Ok(breeds);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteBreed(int id)
	{
		var existingBreed = await _breedService.GetBreedByIdAsync(id);
		if (existingBreed == null)
			return NotFound();

		await _breedService.DeleteBreedAsync(existingBreed);

		return NoContent();
	}

	[HttpGet("{id}/random-fact")]
	public async Task<IActionResult> GetRandomFact(int id)
	{
		try
		{
			// Validate the ID using the static BreedValidation class
			BreedValidation.ValidateBreedId(id);

			// Fetch the random fact
			var fact = await _breedFactGeneratorService.GetRandomFactForBreedAsync(id);

			if (fact == null)
				return NotFound("No facts available for the specified breed.");

			return Ok(fact);
		}
		catch (ArgumentException ex)
		{
			return BadRequest(ex.Message);
		}
		catch (Exception)
		{
			// Return a 500 Internal Server Error for unexpected exceptions
			return StatusCode(500, "An unexpected error occurred.");
		}
	}
}