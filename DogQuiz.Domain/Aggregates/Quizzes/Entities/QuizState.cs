namespace DogQuiz.Domain.Aggregates.Quizzes.Entities;

public class QuizState
{
	public enum QuizLifecycleState
	{
		Pending,
		InProgress,
		Paused,
		Completed,
		Cancelled
	}

	public QuizLifecycleState CurrentState { get; private set; }
	public int TotalQuestions { get; private set; }
	public int TotalCorrectAnswers { get; private set; }
	public int Points { get; private set; }

	public QuizState(QuizLifecycleState initialState, int totalQuestions)
	{
		if (totalQuestions <= 0)
			throw new ArgumentException("Total questions must be greater than zero.", nameof(totalQuestions));

		CurrentState = initialState;
		TotalQuestions = totalQuestions;
	}

	// Transition to a new state
	public void TransitionTo(QuizLifecycleState newState)
	{
		if (!IsValidTransition(newState))
			throw new InvalidOperationException($"Cannot transition from {CurrentState} to {newState}.");

		CurrentState = newState;
	}

	// Add a correct answer and update points
	public void RecordCorrectAnswer(int pointsPerQuestion)
	{
		TotalCorrectAnswers++;
		Points += pointsPerQuestion;
	}

	// Validate state transitions
	private bool IsValidTransition(QuizLifecycleState newState)
	{
		return (CurrentState, newState) switch
		{
			(QuizLifecycleState.Pending, QuizLifecycleState.InProgress) => true,
			(QuizLifecycleState.InProgress, QuizLifecycleState.Paused) => true,
			(QuizLifecycleState.InProgress, QuizLifecycleState.Completed) => true,
			(QuizLifecycleState.InProgress, QuizLifecycleState.Cancelled) => true,
			(QuizLifecycleState.Paused, QuizLifecycleState.InProgress) => true,
			(QuizLifecycleState.Paused, QuizLifecycleState.Cancelled) => true,
			(_, QuizLifecycleState.Cancelled) => true, // Any state can transition to Cancelled
			_ => false
		};
	}
}