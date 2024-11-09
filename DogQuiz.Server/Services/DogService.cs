using DogQuiz.Server.DTOs;
using DogQuiz.Server.Services.Interfaces;

namespace DogQuiz.Server.Services;

public class DogService : IDogService
{
    public Task<DogDTO> CreateDog(DogDTO dogDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteDog(int dogId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DogDTO>> GetAllDogs()
    {
        throw new NotImplementedException();
    }

    public Task<DogDTO> GetDogById(int dogId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateDog(int dogId, DogDTO dogDto)
    {
        throw new NotImplementedException();
    }
}
