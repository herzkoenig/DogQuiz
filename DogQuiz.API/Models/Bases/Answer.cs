using DogQuiz.API.Models.Enums;

namespace DogQuiz.API.Models.Bases;
public abstract class Answer : AuditableEntityWithSoftDelete
{
	public int Id { get; set; }
	public AnswerType Type { get; set; }
	public required Question Question { get; set; }

}
