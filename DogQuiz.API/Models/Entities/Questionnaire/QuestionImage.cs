using DogQuiz.API.Models.Bases;
using DogQuiz.API.Models.Entities.General;
using DogQuiz.API.Models.Enums;

namespace DogQuiz.API.Models.Entities.Questionnaire;

public class QuestionImage : Question
{
	public QuestionImage()
	{
		Type = QuestionType.Image;
	}
	public QuestionImageType? ImageQuestionType { get; set; } = QuestionImageType.StaticQuestion;
	public ImageDetail? Image { get; set; }
}
