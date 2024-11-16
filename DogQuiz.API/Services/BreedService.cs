using DogQuiz.Data.Dtos;
using DogQuiz.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using DogQuiz.Data;

namespace DogQuiz.API.Services;

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

		//if (!breed.IsValid())
		//{
		//    throw new InvalidOperationException("The breed must have at least one alternative name.");
		//}
	}

	public Task DeleteDog(int dogId)
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<BreedDto>> GetAllBreeds()
	{
		return await _context.Breeds.Select(b => new BreedDto
		{
			Name = b.Name,
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
