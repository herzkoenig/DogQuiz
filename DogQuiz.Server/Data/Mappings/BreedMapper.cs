using DogQuiz.Server.Models.Dtos;
using DogQuiz.Server.Models.Entities;
using Riok.Mapperly.Abstractions;

[Mapper]
public partial class BreedMapper
{
    public partial BreedDto MapToBreedDto(Breed breed);
}
