using DogQuiz.Data.Dtos;

namespace DogQuiz.API.Services.Interfaces;

public interface IFactService
{
	Task<IEnumerable<FactDto>> GetAllFacts(int? breedId = null, string? factType = null);
	Task<FactDto> GetFactById(int factId);
	Task<FactDto> AddFact(FactCreateDto factCreateDto);
	Task<FactDto> UpdateFact(int factId, FactUpdateDto factUpdateDto);
	Task<bool> DeleteFact(int factId);
}
