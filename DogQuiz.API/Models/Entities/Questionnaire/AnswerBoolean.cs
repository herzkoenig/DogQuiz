using DogQuiz.API.Models.Bases;
using DogQuiz.API.Models.Enums;

namespace DogQuiz.API.Models.Entities.Questionnaire;

public class AnswerBoolean : Answer
{
	public AnswerBoolean()
	{
		Type = AnswerType.TrueFalse;
	}
	public bool? Bool { get; set; }
}