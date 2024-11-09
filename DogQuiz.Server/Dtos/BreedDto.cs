
using DogQuiz.Server.Models;
using DogQuiz.Server.Models.Enums;

namespace DogQuiz.Server.Dtos;

public class BreedDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<NameInfo>? AlternateNames { get; set; }
    public ImageInfo? Image { get; set; }
    public List<ImageInfo>? OtherImages { get; set; }
    public string? Origin { get; set; }
    public List<BreedRole>? Roles { get; set; }
    public int? QuizDifficulty { get; set; }
    public List<NotableDog>? NotableDogs { get; set; }
    public List<FamousOwner>? FamousOwners { get; set; }
    public List<BreedFact>? Facts { get; set; }
    public List<string> QuizQuestions { get; set; } = new List<string>();
}