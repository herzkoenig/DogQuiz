using DogQuiz.Server.Models.Enums;

namespace DogQuiz.Server.Models;

public class TextQuestion
{
    public int Id { get; set; }
    public int BreedId { get; set; }
    public ImageQuestionType Type { get; set; }
    public string? Title { get; set; }
    public string Question { get; set; }
    public Answer Answer { get; set; }
    public int? Difficulty { get; set; }
    public Breed Breed { get; set; }
}