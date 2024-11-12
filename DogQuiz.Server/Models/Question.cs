using DogQuiz.Server.Models.Enums;

namespace DogQuiz.Server.Models;

public class Question : AuditableEntity
{
    public int Id { get; set; }
    public int? BreedId { get; set; }
    public QuestionType QuestionType { get; set; }
    public TextQuestionType? TextQuestionType { get; set; }
    public ImageQuestionType? ImageQuestionType { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public Answer Answer { get; set; }
    public int? Difficulty { get; set; }
    public Breed? Breed { get; set; }
}