namespace DogQuiz.Data.Dtos;

public class QuestionDto
{
    public Guid QuestionId { get; set; }
    public required string Text { get; set; }
    public List<string> Options { get; set; } = [];
    public string? ImageUrl { get; set; }
    public int QuestionNumber { get; set; }
    public int TotalQuestions { get; set; }
}