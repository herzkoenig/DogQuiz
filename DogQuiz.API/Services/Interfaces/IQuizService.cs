using DogQuiz.Data.Dtos;

namespace DogQuiz.API.Services.Interfaces;

public interface IQuizService
{
	/// <summary>
	/// Retrieves a list of all quizzes.
	/// </summary>
	/// <returns>A list of QuizDto objects.</returns>
	Task<IEnumerable<QuestionDto>> GetAllQuizzes();

	/// <summary>
	/// Retrieves a quiz by its unique identifier.
	/// </summary>
	/// <param name="quizId">The ID of the quiz.</param>
	/// <returns>The QuizDto object if found, otherwise null.</returns>
	Task<QuestionDto> GetQuizById(int quizId);

	/// <summary>
	/// Creates a new quiz in the system.
	/// </summary>
	/// <param name="quizDto">The data transfer object representing the quiz to be created.</param>
	/// <returns>The created QuizDto object.</returns>
	Task<QuestionDto> CreateQuiz(QuestionDto quizDto);

	/// <summary>
	/// Updates an existing quiz by its ID.
	/// </summary>
	/// <param name="quizId">The ID of the quiz to update.</param>
	/// <param name="quizDto">The data transfer object containing updated fields.</param>
	Task UpdateQuiz(int quizId, QuestionDto quizDto);

	/// <summary>
	/// Deletes a quiz by its ID.
	/// </summary>
	/// <param name="quizId">The ID of the quiz to delete.</param>
	Task DeleteQuiz(int quizId);

	/// <summary>
	/// Starts a quiz, initializing it and returning the first set of questions.
	/// </summary>
	/// <param name="quizId">The ID of the quiz to start.</param>
	/// <returns>An object containing the initial questions of the quiz.</returns>
	//Task<QuizSettingsDto> StartQuiz(int quizId);

	/// <summary>
	/// Submits answers for a quiz and returns the result.
	/// </summary>
	/// <param name="quizId">The ID of the quiz being submitted.</param>
	/// <param name="quizSubmissionDto">The data transfer object containing quiz answers.</param>
	/// <returns>An object containing the results of the quiz submission.</returns>
	//Task<QuizResultDto> SubmitQuiz(int quizId, QuizSubmissionDto quizSubmissionDto);
}
