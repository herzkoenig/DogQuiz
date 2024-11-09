using DogQuiz.Server.Dtos;

namespace DogQuiz.Server.Services.Interfaces;

public interface IDogService
{
    /// <summary>
    /// Retrieves a list of all dogs.
    /// </summary>
    /// <returns>A list of DogDto objects.</returns>
    Task<IEnumerable<DogDto>> GetAllDogs();

    /// <summary>
    /// Retrieves a dog by its unique identifier.
    /// </summary>
    /// <param name="dogId">The ID of the dog.</param>
    /// <returns>The DogDto object if found, otherwise null.</returns>
    Task<DogDto> GetDogById(int dogId);

    /// <summary>
    /// Creates a new dog in the system.
    /// </summary>
    /// <param name="dogDto">The data transfer object representing the dog to be created.</param>
    /// <returns>The created DogDto object.</returns>
    Task<DogDto> CreateDog(DogDto dogDto);

    /// <summary>
    /// Updates an existing dog by its ID.
    /// </summary>
    /// <param name="dogId">The ID of the dog to update.</param>
    /// <param name="dogDto">The data transfer object containing updated fields.</param>
    Task UpdateDog(int dogId, DogDto dogDto);

    /// <summary>
    /// Deletes a dog by its ID.
    /// </summary>
    /// <param name="dogId">The ID of the dog to delete.</param>
    Task DeleteDog(int dogId);
}
