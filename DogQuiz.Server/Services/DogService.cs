using DogQuiz.Server.Dtos;
using DogQuiz.Server.Services.Interfaces;

namespace DogQuiz.Server.Services;

public class DogService : IDogService
{
    public Task<DogDto> CreateDog(DogDto dogDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteDog(int dogId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DogDto>> GetAllDogs()
    {
        throw new NotImplementedException();
    }

    public Task<DogDto> GetDogById(int dogId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateDog(int dogId, DogDto dogDto)
    {
        throw new NotImplementedException();
    }
}
