using DogQuiz.Data.Entities.Bases;
using DogQuiz.Data.Enums;

namespace DogQuiz.Data.Entities.Questionnaire;

public class AnswerBoolean : Answer
{
    public AnswerBoolean()
    {
        Type = AnswerType.TrueFalse;
    }
    public bool? Bool { get; set; }
}