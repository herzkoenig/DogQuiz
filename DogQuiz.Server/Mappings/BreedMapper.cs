using DogQuiz.Server.Dtos;
using DogQuiz.Server.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public partial class BreedMapper
{
    public partial BreedDto MapToBreedDto(Breed breed);
}
