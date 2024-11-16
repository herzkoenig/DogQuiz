using DogQuiz.Data.Entities.Bases;

namespace DogQuiz.Data.Entities.Breeds;

public class BreedCollection : IBreedCollection
{
    public int Id { get; set; }
    public string? CollectionName { get; set; }
    public ICollection<Breed> Breeds { get; } = [];
    public ICollection<BreedVariety> BreedVarieties { get; } = [];
    public ICollection<BreedMix> BreedMixes { get; } = [];
}
