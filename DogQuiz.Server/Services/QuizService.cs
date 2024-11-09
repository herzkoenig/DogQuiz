using DogQuiz.Server.Dtos;
using DogQuiz.Server.Services.Interfaces;

namespace DogQuiz.Server.Services;

public class QuizService : IQuizService
{
    public Task<QuizDto> CreateQuiz(QuizDto quizDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteQuiz(int quizId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<QuizDto>> GetAllQuizzes()
    {
        throw new NotImplementedException();
    }

    public Task<QuizDto> GetQuizById(int quizId)
    {
        throw new NotImplementedException();
    }

    public Task<QuizStartDto> StartQuiz(int quizId)
    {
        throw new NotImplementedException();
    }

    public Task<QuizResultDto> SubmitQuiz(int quizId, QuizSubmissionDto quizSubmissionDto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateQuiz(int quizId, QuizDto quizDto)
    {
        throw new NotImplementedException();
    }
}
