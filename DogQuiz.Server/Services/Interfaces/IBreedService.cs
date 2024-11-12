using DogQuiz.Server.Models.Dtos;

namespace DogQuiz.Server.Services.Interfaces;

public interface IBreedService
{
    /// <summary>
    /// Retrieves a list of all dogs.
    /// </summary>
    /// <returns>A list of BreedDto objects.</returns>
    Task<IEnumerable<BreedDto>> GetAllBreeds();

    /// <summary>
    /// Retrieves a dog by its unique identifier.
    /// </summary>
    /// <param name="dogId">The ID of the dog.</param>
    /// <returns>The BreedDto object if found, otherwise null.</returns>
    Task<BreedDto> GetBreedById(int dogId);

    /// <summary>
    /// Creates a new dog in the system.
    /// </summary>
    /// <param name="dogDto">The data transfer object representing the dog to be created.</param>
    /// <returns>The created BreedDto object.</returns>
    Task<BreedDto> CreateBreed(BreedDto dogDto);

    /// <summary>
    /// Updates an existing dog by its ID.
    /// </summary>
    /// <param name="dogId">The ID of the dog to update.</param>
    /// <param name="dogDto">The data transfer object containing updated fields.</param>
    Task UpdateBreed(int dogId, BreedDto dogDto);

    /// <summary>
    /// Deletes a dog by its ID.
    /// </summary>
    /// <param name="dogId">The ID of the dog to delete.</param>
    Task DeleteDog(int dogId);
}
