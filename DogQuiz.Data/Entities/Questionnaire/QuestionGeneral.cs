using DogQuiz.Data.Entities.Bases;
using DogQuiz.Data.Enums;

namespace DogQuiz.Data.Entities.Questionnaire;

public class QuestionGeneral : Question
{
    public QuestionGeneral()
    {
        Type = QuestionType.General;
    }
}
