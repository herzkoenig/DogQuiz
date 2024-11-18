namespace DogQuiz.Data.Entities.Bases;

internal interface IQuestionable
{
    public ICollection<Question> Questions { get; }
}