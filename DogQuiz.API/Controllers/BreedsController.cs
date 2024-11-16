﻿using DogQuiz.Data.Dtos;
using DogQuiz.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DogQuiz.Data;

namespace DogQuiz.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BreedsController : ControllerBase
{
	private readonly ApplicationDbContext _context;
	private readonly IBreedService _breedService;

	public BreedsController(ApplicationDbContext context, IBreedService breedService)
	{
		_context = context;
		_breedService = breedService;
	}

	[HttpGet]
	[ProducesResponseType(typeof(List<BreedDto>), StatusCodes.Status200OK)]
	public async Task<IActionResult> GetAll()
	{

		var breeds = await _breedService.GetAllBreeds();

		return Ok(breeds);
	}

	//[HttpGet("{id:int}")]
	//[ProducesResponseType(typeof(Breed), StatusCodes.Status200OK)]
	//[ProducesResponseType(StatusCodes.Status404NotFound)]
	//public async Task<IActionResult> Get(int id)
	//{
	//    var breed = await _context.Breeds.FindAsync(id);

	//    return breed == null ? NotFound() : Ok(breed);
	//}

	//[HttpPost]
	//[ProducesResponseType(typeof(Breed), StatusCodes.Status201Created)]
	//public async Task<IActionResult> Create([FromBody] Breed breed)
	//{
	//    await _context.Breeds.AddAsync(breed);
	//    await _context.SaveChangesAsync();

	//    return CreatedAtAction(nameof(Get), new { id = breed.Id }, breed);
	//}

	//[HttpPut]
	//[ProducesResponseType(typeof(Breed), StatusCodes.Status200OK)]
	//[ProducesResponseType(StatusCodes.Status404NotFound)]
	//public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BreedDto breedDto)
	//{
	//    var existingBreed = await _context.Breeds.FindAsync(id);

	//    if (existingBreed is null)
	//        return NotFound();

	//    existingBreed.Name = breedDto.Name ?? existingBreed.Name;
	//    // TODO: extend/update! maybe use reflection for this?

	//    await _context.SaveChangesAsync();

	//    return Ok(existingBreed);
	//}

	//[HttpDelete]
	//[ProducesResponseType(StatusCodes.Status200OK)]
	//[ProducesResponseType(StatusCodes.Status404NotFound)]
	//public async Task<IActionResult> Remove([FromRoute] int id)
	//{
	//    var existingBreed = await _context.Breeds.FindAsync(id);

	//    if (existingBreed is null)
	//        return NotFound();

	//    // Any of these options will remove the breed from the context.
	//    // _context.Remove(existingBreed);
	//    // _context.Breeds.Remove(new Breed { Id = id});
	//    _context.Breeds.Remove(existingBreed);

	//    await _context.SaveChangesAsync();

	//    return Ok();
	//}

	//[HttpGet("{Guid:Guid}/images")]
	//[ProducesResponseType(typeof(List<ImageDetail>), StatusCodes.Status200OK)]
	//[ProducesResponseType(StatusCodes.Status404NotFound)]
	//public async Task<IActionResult> GetImages(int id)
	//{
	//    var breed = await _context.Breeds.Include(d => d.OtherImages).FirstOrDefaultAsync(d => d.Id == id);

	//    if (breed == null)
	//        return NotFound();

	//    return Ok(breed.OtherImages);
	//}
}