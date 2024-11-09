using DogQuiz.Server.Data;
using DogQuiz.Server.Dtos;
using DogQuiz.Server.Models;
using DogQuiz.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BreedsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IBreedService _dogService;

    public BreedsController(ApplicationDbContext context, IBreedService dogService)
    {
        _context = context;
        _dogService = dogService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Breed>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Breeds.ToListAsync());
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Breed), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var dog = await _context.Breeds.FindAsync(id);

        return dog == null ? NotFound() : Ok(dog);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Breed), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] Breed dog)
    {
        await _context.Breeds.AddAsync(dog);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = dog.Id }, dog);
    }

    [HttpPut]
    [ProducesResponseType(typeof(Breed), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BreedDto dogDto)
    {
        var existingDog = await _context.Breeds.FindAsync(id);

        if (existingDog is null)
            return NotFound();

        existingDog.Name = dogDto.Name ?? existingDog.Name;
        existingDog.Origin = dogDto.Origin ?? existingDog.Origin;
        existingDog.Roles = dogDto.Roles ?? existingDog.Roles;
        existingDog.Size = dogDto.Size ?? existingDog.Size;
        existingDog.NotableDogs = dogDto.NotableDogs ?? existingDog.NotableDogs;
        existingDog.CelebrityOwners = dogDto.CelebrityOwners ?? existingDog.CelebrityOwners;
        // TODO: extend/update! maybe use reflection for this?


        await _context.SaveChangesAsync();

        return Ok(existingDog);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Remove([FromRoute] int id)
    {
        var existingDog = await _context.Breeds.FindAsync(id);

        if (existingDog is null)
            return NotFound();

        // Any of these options will remove the dog from the context.
        // _context.Remove(existingDog);
        // _context.Breeds.Remove(new Breed { Id = id});
        _context.Breeds.Remove(existingDog);

        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpGet("{Guid:Guid}/images")]
    [ProducesResponseType(typeof(List<ImageInfo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetImages(Guid id)
    {
        var dog = await _context.Breeds.Include(d => d.Images).FirstOrDefaultAsync(d => d.Id == id);

        if (dog == null)
            return NotFound();

        return Ok(dog.Images);
    }

    [HttpGet("{Name:string}/images")]
    [ProducesResponseType(typeof(List<ImageInfo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetImages(string name)
    {
        var dog = await _context.Breeds.Include(d => d.Images).FirstOrDefaultAsync(d => d.Name == name);

        if (dog == null)
            return NotFound();

        return Ok(dog.Images);
    }
}