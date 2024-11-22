using DogQuiz.Application.BreedManagement.Interfaces;
using DogQuiz.Domain.Aggregates.Breeds.Entities;
using DogQuiz.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Application.BreedManagement.Services;
public class BreedService : IBreedService
{
	private readonly ApplicationDbContext _context;

	public BreedService(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<Breed> CreateBreedAsync(Breed breed)
	{
		_context.Breeds.Add(breed);
		await _context.SaveChangesAsync();
		return breed;
	}

	public async Task<Breed?> GetBreedByIdAsync(int id)
	{
		return await _context.Breeds
			.Include(b => b.AdditionalNames)
			.Include(b => b.BreedTags)
			.FirstOrDefaultAsync(b => b.Id == id);
	}

	public async Task<IEnumerable<Breed>> GetAllBreedsAsync()
	{
		return await _context.Breeds
			.Include(b => b.AdditionalNames)
			.Include(b => b.BreedTags)
			.ToListAsync();
	}

	public async Task<Breed> UpdateBreedAsync(Breed breed)
	{
		_context.Breeds.Update(breed);
		await _context.SaveChangesAsync();
		return breed;
	}

	public async Task DeleteBreedAsync(Breed breed)
	{
		_context.Breeds.Remove(breed);
		await _context.SaveChangesAsync();
	}
}