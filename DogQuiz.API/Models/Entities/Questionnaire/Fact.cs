using DogQuiz.API.Models.Bases;
using DogQuiz.API.Models.Entities.Breeds;
using DogQuiz.API.Models.Enums;

namespace DogQuiz.API.Models.Entities.Questionnaire;

public class Fact : AuditableEntityWithSoftDelete
{
	public int Id { get; set; }
	public FactType Type { get; set; }
	public required string Content { get; set; }
	public Breed? Breed { get; set; }
}