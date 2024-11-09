using DogQuiz.Server.Dtos;
using DogQuiz.Server.Services.Interfaces;

namespace DogQuiz.Server.Services;

public class BreedService : IBreedService
{
    public Task<BreedDto> CreateBreed(BreedDto dogDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteDog(int dogId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BreedDto>> GetAllBreeds()
    {
        throw new NotImplementedException();
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
