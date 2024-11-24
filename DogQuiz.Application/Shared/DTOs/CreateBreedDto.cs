using DogQuiz.Domain.Breeds.Entities;
using Riok.Mapperly.Abstractions;

namespace DogQuiz.Application.Shared.DTOs;
public class CreateBreedDto
{
	public string Name { get; set; }
	public string? Description { get; set; }
}

