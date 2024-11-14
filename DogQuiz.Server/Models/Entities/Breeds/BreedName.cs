using DogQuiz.Server.Models.Bases;

namespace DogQuiz.Server.Models.Entities.Breeds;

public class BreedName : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public int BreedId { get; set; }
    public int? BreedVarietyId { get; set; }
    public required string Name { get; set; }
    public Breed? Breed { get; set; }
    public BreedVariety? BreedVariety { get; set; }
}