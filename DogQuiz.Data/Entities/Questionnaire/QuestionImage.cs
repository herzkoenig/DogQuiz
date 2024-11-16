using DogQuiz.Data.Entities.Bases;
using DogQuiz.Data.Entities.General;
using DogQuiz.Data.Enums;

namespace DogQuiz.Data.Entities.Questionnaire;

public class QuestionImage : Question
{
    public QuestionImage()
    {
        Type = QuestionType.Image;
    }
    public QuestionImageType? ImageQuestionType { get; set; } = QuestionImageType.StaticQuestion;
    public ImageDetail? Image { get; set; }
}
