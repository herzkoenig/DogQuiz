using DogQuiz.Data.Entities.Breeds;

namespace DogQuiz.Data.Entities.Bases;

public interface IBreedCollection
{
    public ICollection<Breed> Breeds { get; }
    public ICollection<BreedVariety> BreedVarieties { get; }
    public ICollection<BreedMix> BreedMixes { get; }
}
