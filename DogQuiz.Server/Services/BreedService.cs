using DogQuiz.Server.Data;
using DogQuiz.Server.Dtos;
using DogQuiz.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Server.Services;

public class BreedService : IBreedService
{

    private readonly ApplicationDbContext _context;

    public BreedService(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<BreedDto> CreateBreed(BreedDto dogDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteDog(int dogId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<BreedDto>> GetAllBreeds()
    {
        return await _context.Breeds.Select(b => new BreedDto
        {
            Id = b.Id,
            Name = b.Name,
            Origin = b.Origin,
        }).ToListAsync();
    }

    public Task<BreedDto> GetBreedById(int dogId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateBreed(int dogId, BreedDto dogDto)
    {
        throw new NotImplementedException();
    }
}
