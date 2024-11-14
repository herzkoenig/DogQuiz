using DogQuiz.Server.Models.Bases;

namespace DogQuiz.Server.Models.Entities.Breeds;

public class BreedVariety : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public Breed Breed { get; set; }
}