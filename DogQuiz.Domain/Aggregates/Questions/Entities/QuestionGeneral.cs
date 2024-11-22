using DogQuiz.Domain.Aggregates.Questions.Bases;
using DogQuiz.Domain.Aggregates.Questions.Enums;

namespace DogQuiz.Domain.Aggregates.Questions.Entities;

public class QuestionGeneral : Question
{
	public QuestionGeneral()
	{
		QuestionType = QuestionType.General;
	}
}
