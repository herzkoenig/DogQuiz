namespace DogQuiz.Domain.Questions.Entities;

public class Choice
{
	public int Id { get; set; }
	public string Text { get; set; } = string.Empty;
	public bool IsCorrect { get; set; }
	// How to link to Image? Do i need that?
}