using DogQuiz.Data.Entities.Bases;
using DogQuiz.Data.Enums;

namespace DogQuiz.Data.Entities.Breeds;

public class BreedRole : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public required BreedRoleType Role { get; set; }
    public required Breed Breed { get; set; }
}
