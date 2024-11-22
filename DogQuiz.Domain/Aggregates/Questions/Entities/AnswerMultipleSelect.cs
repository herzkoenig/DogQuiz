using DogQuiz.Domain.Aggregates.Questions.Bases;
using DogQuiz.Domain.Aggregates.Questions.Enums;

namespace DogQuiz.Domain.Aggregates.Questions.Entities;

public class AnswerMultipleSelect : Answer
{
	public AnswerMultipleSelect()
	{
		Type = AnswerType.MultipleSelect;
	}
	public IEnumerable<Choice> Choices { get; } = new List<Choice>();
}
