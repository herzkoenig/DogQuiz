using DogQuiz.API.Models.Bases;
using DogQuiz.API.Models.Enums;

namespace DogQuiz.API.Models.Entities.Questionnaire;

public class QuestionText : Question
{
	public QuestionText()
	{
		Type = QuestionType.Text;
	}
	public QuestionTextType? TextQuestionType { get; set; }
}
