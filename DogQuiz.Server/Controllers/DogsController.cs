using DogQuiz.Server.Data;
using DogQuiz.Server.Models;
using DogQuiz.Server.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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
}
