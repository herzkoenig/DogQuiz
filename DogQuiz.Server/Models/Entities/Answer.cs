using DogQuiz.Server.Models.Auditing;
using DogQuiz.Server.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DogQuiz.Server.Models.Entities;

public class Answer : AuditableEntity
{
    public int Id { get; set; }
    [Required]
    public int QuestionId { get; set; }
    public AnswerType Type { get; set; }
    public string? Text { get; set; }
    public bool? BooleanAnswer { get; set; }
    public List<string>? ListAnswers { get; set; }
    public Question Question { get; set; }
    //public List<string>? MultipleChoiceAnswers { get; set; }
}