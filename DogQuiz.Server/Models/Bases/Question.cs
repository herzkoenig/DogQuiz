using DogQuiz.Server.Models.Enums;
using DogQuiz.Server.Models.Entities.Questionnaire;
using DogQuiz.Server.Models.Entities.Breeds;

namespace DogQuiz.Server.Models.Bases;

public class Question : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
    public QuestionType Type { get; set; }
    public int? Difficulty { get; set; }
    public Breed? Breed { get; set; }
    public required Answer Answer { get; set; }
    //public int? BreedId { get; set; }
    //public required int AnswerId { get; set; }
}