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
        //var dog = await _context.Dogs.FirstOrDefaultAsync(d => d.Id == id);
        //var dog = await _context.Dogs.SingleOrDefaultAsync(d => d.Id == id);
        var dog = await _context.Dogs.FindAsync(id);

        return dog == null ? NotFound() : Ok(dog);

    }
}
