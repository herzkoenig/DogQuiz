using DogQuiz.API.Models.Bases;

namespace DogQuiz.API.Models.Entities.Breeds;

public class BreedVariety : AuditableEntityWithSoftDelete
{
	public int Id { get; set; }
	public required string Name { get; set; }
	public required Breed Breed { get; set; }
}