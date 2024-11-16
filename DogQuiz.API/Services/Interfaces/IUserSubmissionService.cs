using DogQuiz.Data.Dtos;

namespace DogQuiz.API.Services.Interfaces;

public interface IUserSubmissionService
{
	Task<IEnumerable<SubmissionDto>> GetUserSubmissionsAsync(int userId);
	Task<SubmissionResultDto> SubmitQuizResultAsync(int userId, QuizSubmissionDto quizSubmissionDto);
	Task<bool> DeleteSubmissionAsync(int userId, int submissionId);
}
