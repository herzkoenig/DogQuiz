using DogQuiz.Server.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DogQuiz.Server.Models;

public class Breed
{
    public int Id { get; set; }
    public string Name { get; set; }
    public BreedName PrimaryName => AlternativeNames.FirstOrDefault(bn => bn.IsPrimary);
    public List<BreedName> AlternativeNames { get; set; } = new List<BreedName>();
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

