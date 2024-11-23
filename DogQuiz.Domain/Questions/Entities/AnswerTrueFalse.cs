using DogQuiz.Domain.Questions.Bases;
using DogQuiz.Domain.Questions.Enums;

namespace DogQuiz.Domain.Questions.Entities;

public class AnswerTrueFalse : Answer
{
	public AnswerTrueFalse()
	{
		Type = AnswerType.TrueFalse;
	}
	public required bool Answer { get; set; }
}
