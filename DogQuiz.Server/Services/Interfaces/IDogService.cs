using DogQuiz.Server.DTOs;

namespace DogQuiz.Server.Services.Interfaces;

public interface IDogService
{
    /// <summary>
    /// Retrieves a list of all dogs.
    /// </summary>
    /// <returns>A list of DogDTO objects.</returns>
    Task<IEnumerable<DogDTO>> GetAllDogs();

    /// <summary>
    /// Retrieves a dog by its unique identifier.
    /// </summary>
    /// <param name="dogId">The ID of the dog.</param>
    /// <returns>The DogDTO object if found, otherwise null.</returns>
    Task<DogDTO> GetDogById(int dogId);

    /// <summary>
    /// Creates a new dog in the system.
    /// </summary>
    /// <param name="dogDto">The data transfer object representing the dog to be created.</param>
    /// <returns>The created DogDTO object.</returns>
    Task<DogDTO> CreateDog(DogDTO dogDto);

    /// <summary>
    /// Updates an existing dog by its ID.
    /// </summary>
    /// <param name="dogId">The ID of the dog to update.</param>
    /// <param name="dogDto">The data transfer object containing updated fields.</param>
    Task UpdateDog(int dogId, DogDTO dogDto);

    /// <summary>
    /// Deletes a dog by its ID.
    /// </summary>
    /// <param name="dogId">The ID of the dog to delete.</param>
    Task DeleteDog(int dogId);
}
