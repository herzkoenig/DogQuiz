using DogQuiz.Server.Models.Bases;
using DogQuiz.Server.Models.Enums;

namespace DogQuiz.Server.Models.Entities.Questionnaire;

public class QuestionText : Question
{
    public QuestionText()
    {
        Type = QuestionType.Text;
    }
    public QuestionTextType? TextQuestionType { get; set; }
}
