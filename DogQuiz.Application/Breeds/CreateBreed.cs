using DogQuiz.Application.Shared.DTOs;
using DogQuiz.Application.Shared.Mappers;
using DogQuiz.Domain.Breeds.Entities;
using DogQuiz.Infrastructure;

namespace DogQuiz.Application.Breeds;

public interface ICreateBreed
{
	Task<Breed> CreateBreedAsync(CreateBreedDto dto);
}

public class CreateBreed : ICreateBreed
{
    private readonly ApplicationDbContext _context;

    public CreateBreed(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Breed> CreateBreedAsync(CreateBreedDto dto)
    {
        var breed = BreedMapper.ToBreed(dto);

        _context.Breeds.Add(breed);
        await _context.SaveChangesAsync();

        return breed;
    }
}
