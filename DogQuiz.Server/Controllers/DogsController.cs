using DogQuiz.Server.Data;
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
    public async Task<IActionResult> Update([FromRoute]int id, [FromBody] Dog dog)
    {
        var existingDog = await _context.Dogs.FindAsync(id);

        if(existingDog is null)
            return NotFound();

        existingDog.Name = dog.Name;
        existingDog.NameLocal = dog.NameLocal;
        existingDog.NameFCI = dog.NameFCI;
        existingDog.ImageUrl = dog.ImageUrl;
        existingDog.History = dog.History;
        existingDog.FunFacts = dog.FunFacts;

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
