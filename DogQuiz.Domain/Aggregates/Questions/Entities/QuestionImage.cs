using DogQuiz.Domain.Aggregates.General.Entities;
using DogQuiz.Domain.Aggregates.Questions.Bases;
using DogQuiz.Domain.Aggregates.Questions.Enums;

namespace DogQuiz.Domain.Aggregates.Questions.Entities;

public class QuestionImage : Question
{
	public QuestionImage()
	{
		QuestionType = QuestionType.Image;
	}
	public QuestionImageType? ImageQuestionType { get; set; } = QuestionImageType.StaticQuestion;
	public ImageDetail? Image { get; set; }
}
