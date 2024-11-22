using DogQuiz.Domain.Aggregates.Questions.Bases;
using DogQuiz.Domain.Aggregates.Questions.Enums;

namespace DogQuiz.Domain.Aggregates.Questions.Entities;

public class QuestionText : Question
{
	public QuestionText()
	{
		QuestionType = QuestionType.Text;
	}
	public QuestionTextType? TextQuestionType { get; set; }
}
