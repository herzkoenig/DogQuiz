using DogQuiz.Data.Dtos;
using DogQuiz.API.Services.Interfaces;

namespace DogQuiz.API.Services;

public class QuizService : IQuizService
{
	public Task<QuestionDto> CreateQuiz(QuestionDto quizDto)
	{
		throw new NotImplementedException();
	}

	public Task DeleteQuiz(int quizId)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<QuestionDto>> GetAllQuizzes()
	{
		throw new NotImplementedException();
	}

	public Task<QuestionDto> GetQuizById(int quizId)
	{
		throw new NotImplementedException();
	}

	//public Task<QuizSettingsDto> StartQuiz(int quizId)
	//{
	//    throw new NotImplementedException();
	//}

	//public Task<QuizResultDto> SubmitQuiz(int quizId, QuizSubmissionDto quizSubmissionDto)
	//{
	//    throw new NotImplementedException();
	//}

	public Task UpdateQuiz(int quizId, QuestionDto quizDto)
	{
		throw new NotImplementedException();
	}
}
