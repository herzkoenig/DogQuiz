using DogQuiz.Server.DTOs;
using DogQuiz.Server.Services.Interfaces;

namespace DogQuiz.Server.Services;

public class QuizService : IQuizService
{
    public Task<QuizDTO> CreateQuiz(QuizDTO quizDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteQuiz(int quizId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<QuizDTO>> GetAllQuizzes()
    {
        throw new NotImplementedException();
    }

    public Task<QuizDTO> GetQuizById(int quizId)
    {
        throw new NotImplementedException();
    }

    public Task<QuizStartDTO> StartQuiz(int quizId)
    {
        throw new NotImplementedException();
    }

    public Task<QuizResultDTO> SubmitQuiz(int quizId, QuizSubmissionDTO quizSubmissionDto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateQuiz(int quizId, QuizDTO quizDto)
    {
        throw new NotImplementedException();
    }
}
