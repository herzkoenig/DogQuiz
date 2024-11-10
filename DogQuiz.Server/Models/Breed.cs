using DogQuiz.Server.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DogQuiz.Server.Models;

public class Breed
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; } = default!;
    public List<NameInfo> AlternateNames { get; set; } = new List<NameInfo>();
    public ImageInfo? MainImage { get; set; }
    public List<ImageInfo> AllImages { get; set; } = new List<ImageInfo>();
    public List<BreedVariety> BreedVarieties { get; set; } = new List<BreedVariety>();
    public string? Description { get; set; }
    public string? Origin { get; set; }
    public List<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();
    public List<BreedFact> Facts { get; set; } = new List<BreedFact>();
    public List<BreedRole> Roles { get; set; } = new List<BreedRole>();
    public List<NotableDog> NotableDogs { get; set; } = new List<NotableDog>();
    public List<FamousOwner> FamousOwners { get; set; } = new List<FamousOwner>();
    public ImageQuizMetadata Metadata { get; set; } = new ImageQuizMetadata();
}

