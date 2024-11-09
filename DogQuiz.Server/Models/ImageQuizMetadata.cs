using System.ComponentModel.DataAnnotations;

namespace DogQuiz.Server.Models;

public class ImageQuizMetadata
{
    [Range(1, 10, ErrorMessage = "Quiz difficulty should be between 1 and 10.")]
    public int? QuizDifficulty { get; set; }
    public int CorrectAnswerRate { get; set; }
    public int TimesAppearedInQuiz { get; set; }
}