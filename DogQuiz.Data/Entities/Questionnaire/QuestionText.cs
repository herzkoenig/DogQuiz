using DogQuiz.Data.Entities.Bases;
using DogQuiz.Data.Enums;

namespace DogQuiz.Data.Entities.Questionnaire;

public class QuestionText : Question
{
    public QuestionText()
    {
        Type = QuestionType.Text;
    }
    public QuestionTextType? TextQuestionType { get; set; }
}
