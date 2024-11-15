using DogQuiz.API.Models.Bases;
using DogQuiz.API.Models.Enums;

namespace DogQuiz.API.Models.Entities.Questionnaire;

public class AnswerText : Answer
{
	public AnswerText()
	{
		Type = AnswerType.Text;
	}
	public string? Text { get; set; }
}