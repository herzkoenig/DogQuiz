namespace DogQuiz.Server.Dtos;

public class TextQuizQuestionDto
{
    public Guid QuestionId { get; set; }
    public string QuestionText { get; set; }
    public List<string> Options { get; set; } = new List<string>();
    public string? ImageUrl { get; set; }
    public string? Hint { get; set; }
    public string QuestionType { get; set; }
    public int QuestionNumber { get; set; }
    public int TotalQuestions { get; set; }
}