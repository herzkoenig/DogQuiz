using DogQuiz.API.Dtos;

namespace DogQuiz.API.Services.Interfaces;

public interface IQuestionService
{
	Task<IEnumerable<QuestionDto>> GetAllQuestionsAsync();
	Task<QuestionDto> GetQuestionByIdAsync(int questionId);
	Task<QuestionDetailDto> CreateQuestionAsync(QuestionCreateDto questionCreateDto);
	Task<QuestionDetailDto> UpdateQuestionAsync(int questionId, QuestionUpdateDto questionUpdateDto);
	Task<bool> DeleteQuestionAsync(int questionId);
	Task<IEnumerable<AnswerDto>> GetAnswersForQuestionAsync(int questionId);
	Task<AnswerResultDto> SubmitAnswerAsync(int questionId, AnswerSubmissionDto answerSubmissionDto);
	Task<bool> DeleteAnswerAsync(int questionId, int answerId);
}
