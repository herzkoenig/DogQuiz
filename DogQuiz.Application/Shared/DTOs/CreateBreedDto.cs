using DogQuiz.Domain.Breeds.Entities;
using DogQuiz.Domain.Shared.Entities;

namespace DogQuiz.Application.Shared.DTOs;

public class CreateBreedDto
{
	public string Name { get; set; }
	public string[]? AdditionalNames { get; set; }
	public string? Description { get; set; }
	public List<string> Origin { get; set; }
	public List<string> Roles { get; set; }
	public List<string> BreedTags { get; set; }
}

