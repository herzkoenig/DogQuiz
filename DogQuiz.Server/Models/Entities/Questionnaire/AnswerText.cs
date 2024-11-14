using DogQuiz.Server.Models.Bases;
using DogQuiz.Server.Models.Enums;

namespace DogQuiz.Server.Models.Entities.Questionnaire;

public class AnswerText : Answer
{
    //public AnswerText()
    //{
    //    Type = AnswerType.Text;
    //}
    public string? Text { get; set; }
}