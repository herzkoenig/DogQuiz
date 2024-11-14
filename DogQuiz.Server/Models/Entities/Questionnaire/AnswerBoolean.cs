using DogQuiz.Server.Models.Bases;
using DogQuiz.Server.Models.Enums;

namespace DogQuiz.Server.Models.Entities.Questionnaire;

public class AnswerBoolean : Answer
{
    public AnswerBoolean()
    {
        Type = AnswerType.TrueFalse;
    }
    public bool? Bool { get; set; }
}