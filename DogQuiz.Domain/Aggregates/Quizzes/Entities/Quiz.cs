using DogQuiz.Domain.Aggregates.Questions.Bases;

namespace DogQuiz.Domain.Aggregates.Quizzes.Entities;
public class Quiz
{
	public Guid Id { get; private set; }
	public List<Question> Questions { get; private set; } = new();
	public int DurationMinutes { get; private set; }
	public QuizState State { get; private set; }
	public int CurrentQuestionIndex { get; private set; } = 0;
	public DateTime? StartTime { get; private set; }
	public DateTime? EndTime { get; private set; }

	public Quiz(Guid id, int durationMinutes, List<Question> questions, int pointsPerQuestion)
	{
		if (durationMinutes <= 0)
			throw new ArgumentException("Quiz duration must be greater than zero.", nameof(durationMinutes));

		if (questions == null || questions.Count == 0)
			throw new ArgumentException("A quiz must have at least one question.", nameof(questions));

		Id = id;
		DurationMinutes = durationMinutes;
		Questions = questions;
		State = new QuizState(QuizState.QuizLifecycleState.Pending, questions.Count);
	}

	// Start the Quiz
	public void Start()
	{
		State.TransitionTo(QuizState.QuizLifecycleState.InProgress);
		StartTime = DateTime.UtcNow;
	}

	// Pause the Quiz
	public void Pause()
	{
		State.TransitionTo(QuizState.QuizLifecycleState.Paused);
	}

	// Resume the Quiz
	public void Resume()
	{
		State.TransitionTo(QuizState.QuizLifecycleState.InProgress);
	}

	// Cancel the Quiz
	public void Cancel()
	{
		State.TransitionTo(QuizState.QuizLifecycleState.Cancelled);
		EndTime = DateTime.UtcNow;
	}

	// Finalize the Quiz
	//public void Finalize()
	//{
	//    State.TransitionTo(QuizState.QuizLifecycleState.Completed);
	//    EndTime = DateTime.UtcNow;
	//}

	// Submit an answer
	//public bool SubmitAnswer(Guid choiceId, int pointsPerQuestion, IAnswerValidator validator)
	//{
	//    if (State.CurrentState != QuizState.QuizLifecycleState.InProgress)
	//        throw new InvalidOperationException("Cannot submit answers unless the quiz is 'InProgress'.");

	//    if (HasTimeElapsed())
	//        throw new InvalidOperationException("Quiz time has expired.");

	//    if (CurrentQuestionIndex >= Questions.Count)
	//        throw new InvalidOperationException("No more questions to answer.");

	//    var currentQuestion = Questions[CurrentQuestionIndex];
	//    bool isCorrect = validator.Validate(currentQuestion, choiceId);

	//    if (isCorrect)
	//        State.RecordCorrectAnswer(pointsPerQuestion);

	//    CurrentQuestionIndex++;

	//    // Finalize if all questions are answered
	//    if (CurrentQuestionIndex >= Questions.Count)
	//        Finalize();

	//    return isCorrect;
	//}

	// Check if time has elapsed
	private bool HasTimeElapsed()
	{
		if (StartTime == null) return false;
		return DateTime.UtcNow > StartTime.Value.AddMinutes(DurationMinutes);
	}
}
