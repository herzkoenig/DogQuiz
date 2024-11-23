namespace DogQuiz.Domain.Questions.Bases;

public interface IQuestionHolder
{
	public ICollection<Question> Questions { get; }
}