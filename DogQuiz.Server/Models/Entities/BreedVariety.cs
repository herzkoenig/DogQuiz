using DogQuiz.Server.Models.Auditing;

namespace DogQuiz.Server.Models.Entities;

public class BreedVariety : AuditableEntity
{
    public int Id { get; set; }
    public int BreedId { get; set; }
    public required string Name { get; set; }
    public Breed Breed { get; set; }


}