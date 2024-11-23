using DogQuiz.Domain.Questions.Bases;
using DogQuiz.Domain.Questions.Enums;

namespace DogQuiz.Domain.Questions.Entities;

public class QuestionGeneral : Question
{
	public QuestionGeneral()
	{
		QuestionType = QuestionType.General;
	}
}
