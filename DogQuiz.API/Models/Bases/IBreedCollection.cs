using DogQuiz.API.Models.Entities.Breeds;

namespace DogQuiz.API.Models.Bases;

public interface IBreedCollection
{
	public ICollection<Breed> Breeds { get; }
	public ICollection<BreedVariety> BreedVarieties { get; }
	public ICollection<BreedMix> BreedMixes { get; }
}
