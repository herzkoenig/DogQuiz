
namespace DogQuiz.Server.Dtos;

public class DogDto
{
    public string? Name { get; set; }
    public string? NameLocal { get; set; }
    public string? NameFCI { get; set; }
    public List<string>? AlternativeNames { get; set; }
    public string? ImageUrl { get; set; }
    public string? Origin { get; set; }
    public List<string>? Roles { get; set; }
    public string? Size { get; set; }
    public List<string>? NotableDogs { get; set; }
    public List<string>? CelebrityOwners { get; set; }
    public string? HistoricalFacts { get; set; }
    public string? FunFacts { get; set; }
}