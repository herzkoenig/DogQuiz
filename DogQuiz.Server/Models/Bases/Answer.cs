using DogQuiz.Server.Models.Entities.Questionnaire;
using DogQuiz.Server.Models.Enums;

namespace DogQuiz.Server.Models.Bases;
public abstract class Answer : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public AnswerType Type { get; set; }
    public Question Question { get; set; }

}
