using DogQuiz.Data.Enums;

namespace DogQuiz.Data.Entities.Bases;
public abstract class Answer : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public AnswerType Type { get; set; }
    public required Question Question { get; set; }

}
