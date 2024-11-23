using DogQuiz.Domain.Questions.Bases;
using DogQuiz.Domain.Questions.Enums;

namespace DogQuiz.Domain.Questions.Entities;

public class AnswerSingleSelect : Answer
{
	public AnswerSingleSelect()
	{
		Type = AnswerType.SingleSelect;
	}
	public required Choice Choice { get; set; }
}
