using DogQuiz.Data.Entities.Bases;
using DogQuiz.Data.Enums;

namespace DogQuiz.Data.Entities.Questionnaire;

public class AnswerText : Answer
{
    public AnswerText()
    {
        Type = AnswerType.Text;
    }
    public string? Text { get; set; }
}