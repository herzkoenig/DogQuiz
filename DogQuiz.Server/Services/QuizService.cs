using DogQuiz.Server.Dtos;
using DogQuiz.Server.Services.Interfaces;

namespace DogQuiz.Server.Services;

public class QuizService : IQuizService
{
    public Task<TextQuizQuestionDto> CreateQuiz(TextQuizQuestionDto quizDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteQuiz(int quizId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TextQuizQuestionDto>> GetAllQuizzes()
    {
        throw new NotImplementedException();
    }

    public Task<TextQuizQuestionDto> GetQuizById(int quizId)
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

    public Task UpdateQuiz(int quizId, TextQuizQuestionDto quizDto)
    {
        throw new NotImplementedException();
    }
}
