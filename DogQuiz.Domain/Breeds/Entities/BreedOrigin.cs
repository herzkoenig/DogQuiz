using DogQuiz.Domain.Shared.Bases;
using DogQuiz.Domain.Shared.Entities;

namespace DogQuiz.Domain.Breeds.Entities;

public class BreedOrigin
{
	public int Id { get; set; }
	public ICollection<Country> Countries { get; } = new List<Country>();
	public string? Text { get; set; }
	public string? HistoricalContext { get; set; }
}