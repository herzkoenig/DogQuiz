using DogQuiz.Domain.Aggregates.Breeds.Entities;

namespace DogQuiz.Application.BreedManagement.Interfaces;
public interface IBreedService
{
	Task<Breed> CreateBreedAsync(Breed breed);
	Task<Breed?> GetBreedByIdAsync(int id);
	Task<IEnumerable<Breed>> GetAllBreedsAsync();
	Task<Breed> UpdateBreedAsync(Breed breed);
	Task DeleteBreedAsync(Breed breed);
}
