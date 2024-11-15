using DogQuiz.API.Models.Bases;
using DogQuiz.API.Models.Enums;

namespace DogQuiz.API.Models.Entities.Breeds;

public class BreedRole : AuditableEntityWithSoftDelete
{
	public int Id { get; set; }
	public required BreedRoleType Role { get; set; }
	public required Breed Breed { get; set; }
}
