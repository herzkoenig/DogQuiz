using DogQuiz.API.Models.Bases;

namespace DogQuiz.API.Models.Entities.Breeds;

public class BreedName : AuditableEntityWithSoftDelete
{
	public int Id { get; set; }
	public required string Name { get; set; }
	public Breed? Breed { get; set; }
	public BreedVariety? BreedVariety { get; set; }

}