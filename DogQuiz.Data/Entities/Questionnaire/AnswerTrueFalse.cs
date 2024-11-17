using DogQuiz.Data.Entities.Bases;
using DogQuiz.Data.Enums;

namespace DogQuiz.Data.Entities.Questionnaire;

public class AnswerTrueFalse : Answer
{
    public AnswerTrueFalse()
    {
        Type = AnswerType.TrueFalse;
    }
    public bool? Bool { get; set; }
}