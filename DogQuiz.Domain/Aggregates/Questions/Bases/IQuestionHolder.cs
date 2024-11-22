namespace DogQuiz.Domain.Aggregates.Questions.Bases;

public interface IQuestionHolder
{
	public ICollection<Question> Questions { get; }
}