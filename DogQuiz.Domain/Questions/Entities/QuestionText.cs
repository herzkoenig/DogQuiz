using DogQuiz.Domain.Questions.Bases;
using DogQuiz.Domain.Questions.Enums;

namespace DogQuiz.Domain.Questions.Entities;

public class QuestionText : Question
{
	public QuestionText()
	{
		QuestionType = QuestionType.Text;
	}
	public QuestionTextType? TextQuestionType { get; set; }
}
