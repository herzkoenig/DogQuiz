using DogQuiz.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Application.Breeds.CreateBreedFact;

public class BreedFactGeneratorService : IBreedFactGeneratorService
{
	private readonly ApplicationDbContext _context;

	public BreedFactGeneratorService(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<string?> GetRandomFactForBreedAsync(int breedId)
	{
		// Fetch the breed with its facts
		var breed = await _context.Breeds
			.Include(b => b.Facts)
			.FirstOrDefaultAsync(b => b.Id == breedId);

		if (breed == null || !breed.Facts.Any())
			return null;

		// Select a random fact
		var random = new Random();
		int index = random.Next(breed.Facts.Count);
		return breed.Facts.ElementAt(index).Content;
	}
}
