using DogQuiz.API.Models.Entities.Breeds;
using DogQuiz.API.Models.Enums;

namespace DogQuiz.API.Models.Bases;

public class Question : AuditableEntityWithSoftDelete
{
	public int Id { get; set; }
	public string? Title { get; set; }
	public string? Text { get; set; }
	public QuestionType Type { get; set; }
	public int? Difficulty { get; set; }
	public Breed? Breed { get; set; }
	public required Answer Answer { get; set; }
}