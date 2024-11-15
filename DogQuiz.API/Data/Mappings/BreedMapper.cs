using DogQuiz.API.Dtos;
using DogQuiz.API.Models.Entities.Breeds;
using Riok.Mapperly.Abstractions;

[Mapper]
public partial class BreedMapper
{
#pragma warning disable RMG020, RMG012
	public partial BreedDto MapToBreedDto(Breed breed);
#pragma warning restore
}
