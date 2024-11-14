using DogQuiz.Server.Models.Entities.Breeds;

namespace DogQuiz.Server.Models.Bases
{
public interface IBreedCollection
{
    public ICollection<Breed> Breeds { get; }
    public ICollection<BreedVariety> BreedVarieties { get; }
    public ICollection<BreedMix> BreedMixes { get; }
}
}
