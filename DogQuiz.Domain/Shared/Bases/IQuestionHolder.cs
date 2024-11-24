using DogQuiz.Domain.Questions.Bases;

namespace DogQuiz.Domain.Shared.Bases;

public interface IQuestionHolder
{
	public ICollection<Question> Questions { get; }
}