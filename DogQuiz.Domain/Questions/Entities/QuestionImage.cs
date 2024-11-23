using DogQuiz.Domain.Questions.Bases;
using DogQuiz.Domain.Questions.Enums;
using DogQuiz.Domain.Shared.Entities;

namespace DogQuiz.Domain.Questions.Entities;

public class QuestionImage : Question
{
	public QuestionImage()
	{
		QuestionType = QuestionType.Image;
	}
	public QuestionImageType? ImageQuestionType { get; set; } = QuestionImageType.StaticQuestion;
	public ImageDetail? Image { get; set; }
}
