using DogQuiz.Server.Models.Base;

namespace DogQuiz.Server.Models.Entities;

public class BreedName : AuditableEntity
{
    public int Id { get; set; }
    public int BreedId { get; set; }
    public int? BreedVarietyId { get; set; }
    public required string Name { get; set; }
    public Breed? Breed { get; set; }
    public BreedVariety? BreedVariety { get; set; }
}