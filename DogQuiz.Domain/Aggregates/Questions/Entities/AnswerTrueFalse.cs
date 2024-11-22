using DogQuiz.Domain.Aggregates.Questions.Bases;
using DogQuiz.Domain.Aggregates.Questions.Enums;

namespace DogQuiz.Domain.Aggregates.Questions.Entities;

public class AnswerTrueFalse : Answer
{
	public AnswerTrueFalse()
	{
		Type = AnswerType.TrueFalse;
	}
	public required bool Answer { get; set; }
}
