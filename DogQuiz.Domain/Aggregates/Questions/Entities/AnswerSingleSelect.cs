using DogQuiz.Domain.Aggregates.Questions.Bases;
using DogQuiz.Domain.Aggregates.Questions.Enums;

namespace DogQuiz.Domain.Aggregates.Questions.Entities;

public class AnswerSingleSelect : Answer
{
	public AnswerSingleSelect()
	{
		Type = AnswerType.SingleSelect;
	}
	public required Choice Choice { get; set; }
}
