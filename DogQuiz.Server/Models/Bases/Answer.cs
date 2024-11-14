using DogQuiz.Server.Models.Entities.Questionnaire;
using DogQuiz.Server.Models.Enums;

namespace DogQuiz.Server.Models.Bases;
public class Answer : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public AnswerType Type { get; set; }
    public required Question Question { get; set; }
    //public required int QuestionId { get; set; }

}
