using DogQuiz.Server.Models;
using DogQuiz.Server.Models.Enums;

namespace DogQuiz.Server.Models.Dtos;

public class BreedDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<string> AlternativeNames { get; set; } = new List<string>();
    //public ImageInfoDto? PrimaryImage { get; set; }
    //public List<ImageInfoDto> AdditionalImages { get; set; } = new List<ImageInfoDto>();
    public List<string> Varieties { get; set; } = new List<string>();
    public string? Description { get; set; }
    public string? Origin { get; set; }
    public List<string> QuizQuestions { get; set; } = new List<string>();
    public List<string> Facts { get; set; } = new List<string>();
    public List<string> Roles { get; set; } = new List<string>();
    public List<string> NotableDogs { get; set; } = new List<string>();
    public List<string> NotableOwners { get; set; } = new List<string>();

}