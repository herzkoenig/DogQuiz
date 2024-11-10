using System.ComponentModel.DataAnnotations;

namespace DogQuiz.Server.Models;

public class ImageQuizMetadata
{
    public int Id { get; set; }
    public int BreedId { get; set; }
    public int? QuizDifficulty { get; set; }
    public int CorrectAnswerRate { get; set; }
    public int TimesAppearedInQuiz { get; set; }
    public Breed Breed { get; set; }
}