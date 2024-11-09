using DogQuiz.Server.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogQuiz.Server.Models;

public class Breed
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    public List<NameInfo>? AlternateNames { get; set; } = new List<NameInfo>();
    public ImageInfo? MainImage { get; set; }
    public List<ImageInfo> OtherImages { get; set; } = new List<ImageInfo>();
    public string? Origin { get; set; }
    public List<TextQuizQuestion> QuizQuestions { get; set; } = new List<TextQuizQuestion>();
    public List<BreedRole>? Roles { get; set; }
    [Range(1, 10, ErrorMessage = "Quiz difficulty should be between 1 and 10.")]
    public List<NotableDog> NotableDogs { get; set; } = new List<NotableDog>();
    public List<FamousOwner> FamousOwners { get; set; } = new List<FamousOwner>();
    public List<BreedFact> Facts { get; set; } = new List<BreedFact>();
    public int? QuizDifficulty { get; set; }
    public int CorrectAnswerRate { get; set; }
    public int TimesAppearedInQuiz { get; set; }
    }

