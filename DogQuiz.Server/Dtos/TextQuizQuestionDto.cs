using System.ComponentModel.DataAnnotations;

namespace DogQuiz.Server.Dtos;

public class TextQuizQuestionDto
{
    public Guid QuestionId { get; set; }
    [Required]
    public string QuestionText { get; set; }
    public List<string> Options { get; set; } = new List<string>();
    public string? ImageUrl { get; set; }
    public int QuestionNumber { get; set; }
    public int TotalQuestions { get; set; }
}