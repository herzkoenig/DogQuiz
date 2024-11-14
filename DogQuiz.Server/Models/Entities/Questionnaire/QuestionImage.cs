using DogQuiz.Server.Models.Bases;
using DogQuiz.Server.Models.Entities.General;
using DogQuiz.Server.Models.Enums;

namespace DogQuiz.Server.Models.Entities.Questionnaire;

public class QuestionImage : Question
{
    public QuestionImage()
    {
        Type = QuestionType.Image;
    }
    public QuestionImageType? ImageQuestionType { get; set; } = QuestionImageType.StaticQuestion;
    public ImageDetail? Image { get; set; }
}
