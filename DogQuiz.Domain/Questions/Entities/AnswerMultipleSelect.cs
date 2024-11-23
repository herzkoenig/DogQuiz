using DogQuiz.Domain.Questions.Bases;
using DogQuiz.Domain.Questions.Enums;

namespace DogQuiz.Domain.Questions.Entities;

public class AnswerMultipleSelect : Answer
{
	public AnswerMultipleSelect()
	{
		Type = AnswerType.MultipleSelect;
	}
	public IEnumerable<Choice> Choices { get; } = new List<Choice>();
}
