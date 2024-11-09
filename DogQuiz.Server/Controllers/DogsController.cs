using DogQuiz.Server.Data;
using DogQuiz.Server.Dtos;
using DogQuiz.Server.Models;
using DogQuiz.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DogsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IDogService _dogService;

    public DogsController(ApplicationDbContext context, IDogService dogService)
    {
        _context = context;
        _dogService = dogService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Dog>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Dogs.ToListAsync());
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Dog), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var dog = await _context.Dogs.FindAsync(id);

        return dog == null ? NotFound() : Ok(dog);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Dog), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] Dog dog)
    {
        await _context.Dogs.AddAsync(dog);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = dog.Id }, dog);
    }

    [HttpPut]
    [ProducesResponseType(typeof(Dog), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] DogDto dogDto)
    {
        var existingDog = await _context.Dogs.FindAsync(id);

        if (existingDog is null)
            return NotFound();

        existingDog.Name = dogDto.Name ?? existingDog.Name;
        existingDog.NameLocal = dogDto.NameLocal ?? existingDog.NameLocal;
        existingDog.NameFCI = dogDto.NameFCI ?? existingDog.NameFCI;
        existingDog.AlternativeNames = dogDto.AlternativeNames ?? existingDog.AlternativeNames;
        existingDog.ImageUrl = dogDto.ImageUrl ?? existingDog.ImageUrl;
        existingDog.Origin = dogDto.Origin ?? existingDog.Origin;
        existingDog.Roles = dogDto.Roles ?? existingDog.Roles;
        existingDog.Size = dogDto.Size ?? existingDog.Size;
        existingDog.NotableDogs = dogDto.NotableDogs ?? existingDog.NotableDogs;
        existingDog.CelebrityOwners = dogDto.CelebrityOwners ?? existingDog.CelebrityOwners;
        existingDog.HistoricalFacts = dogDto.HistoricalFacts ?? existingDog.HistoricalFacts;
        existingDog.FunFacts = dogDto.FunFacts ?? existingDog.FunFacts;


        await _context.SaveChangesAsync();

        return Ok(existingDog);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Remove([FromRoute] int id)
    {
        var existingDog = await _context.Dogs.FindAsync(id);

        if (existingDog is null)
            return NotFound();

        // Any of these options will remove the dog from the context.
        // _context.Remove(existingDog);
        // _context.Dogs.Remove(new Dog { Id = id});
        _context.Dogs.Remove(existingDog);

        await _context.SaveChangesAsync();

        return Ok();
    }
}
