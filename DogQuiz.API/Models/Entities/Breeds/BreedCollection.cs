using DogQuiz.API.Models.Bases;

namespace DogQuiz.API.Models.Entities.Breeds;

public class BreedCollection : IBreedCollection
{
	public int Id { get; set; }
	public string? CollectionName { get; set; }
	public ICollection<Breed> Breeds { get; } = [];
	public ICollection<BreedVariety> BreedVarieties { get; } = [];
	public ICollection<BreedMix> BreedMixes { get; } = [];
}
