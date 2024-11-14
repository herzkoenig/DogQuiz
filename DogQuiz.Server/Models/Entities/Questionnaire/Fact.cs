using DogQuiz.Server.Models.Bases;
using DogQuiz.Server.Models.Entities.Breeds;
using DogQuiz.Server.Models.Enums;

namespace DogQuiz.Server.Models.Entities.Questionnaire;

public class Fact : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public int? BreedId { get; set; }
    public FactType Type { get; set; }
    public required string Content { get; set; }
    public Breed? Breed { get; set; }
}