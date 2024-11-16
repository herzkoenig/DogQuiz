using DogQuiz.Data.Entities.Bases;
using DogQuiz.Data.Entities.Breeds;
using DogQuiz.Data.Enums;

namespace DogQuiz.Data.Entities.Questionnaire;

public class Fact : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public FactType Type { get; set; }
    public required string Content { get; set; }
    public Breed? Breed { get; set; }
}