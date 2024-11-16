using DogQuiz.Data.Entities.Bases;

namespace DogQuiz.Data.Entities.Breeds;

public class BreedVariety : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required Breed Breed { get; set; }
}