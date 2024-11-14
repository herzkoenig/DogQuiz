using DogQuiz.Server.Models.Bases;
using DogQuiz.Server.Models.Enums;

namespace DogQuiz.Server.Models.Entities.Questionnaire;

public class AnswerBoolean : Answer
{
    public AnswerBoolean()
    {
        Type = AnswerType.Boolean;
    }
    public required bool Value { get; set; }
}