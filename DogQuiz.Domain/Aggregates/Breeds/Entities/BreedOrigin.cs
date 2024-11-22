using DogQuiz.Domain.Aggregates.General.Entities;

namespace DogQuiz.Domain.Aggregates.Breeds.Entities;

public class BreedOrigin
{
	public int Id { get; set; }
	public ICollection<Country> Countries { get; } = new List<Country>();
	public string? Text { get; set; }
	public string? HistoricalContext { get; set; }
}