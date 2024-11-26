using DogQuiz.Application.Shared.DTOs;
using DogQuiz.Domain.Breeds.Entities;
using Riok.Mapperly.Abstractions;

namespace DogQuiz.Application.Shared.Mappers;

[Mapper]
public static partial class BreedMapper
{
	public static partial Breed ToBreed(CreateBreedDto dto);
	public static partial GetBreedDto ToGetBreedDto(Breed breed);
}