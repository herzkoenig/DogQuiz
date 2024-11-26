using DogQuiz.Application.Breeds;
using Microsoft.AspNetCore.Mvc;
using DogQuiz.Application.Shared.DTOs;
using FluentValidation;
using DogQuiz.Application.Shared.Mappers;

namespace DogQuiz.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BreedsController : ControllerBase
{
	private readonly ICreateBreed _createBreed;
	private readonly IValidator<CreateBreedDto> _createBreedValidator;

	public BreedsController(ICreateBreed createBreed, IValidator<CreateBreedDto> createBreedValidator)
	{
		_createBreed = createBreed;
		_createBreedValidator = createBreedValidator;
	}

	[HttpPost]
	public async Task<IActionResult> CreateBreed([FromBody] CreateBreedDto createBreedDto)
	{
		// Manual validation using FluentValidation
		var validationResult = await _createBreedValidator.ValidateAsync(createBreedDto);

		if (!validationResult.IsValid)
		{
			// Return validation errors as a 400 Bad Request
			return BadRequest(new
			{
				Errors = validationResult.Errors.Select(err => new
				{
					Field = err.PropertyName,
					Message = err.ErrorMessage
				})
			});
		}

		// Proceed with creating the breed
		var createdBreed = await _createBreed.CreateBreedAsync(createBreedDto);
		var resultDto = BreedMapper.ToGetBreedDto(createdBreed);

		// Return created resource
		return CreatedAtAction(nameof(GetBreedById), new { id = createdBreed.Id }, resultDto);
	}

	[HttpGet("{id}")]
	public IActionResult GetBreedById(int id)
	{
		// Placeholder for getting a breed by ID
		return Ok(new { id });
	}
}