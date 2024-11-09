using System.ComponentModel.DataAnnotations;

namespace DogQuiz.Server.Models;

public class Breed
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public List<NameInfo> OtherNames { get; set; } = new List<NameInfo>(); // Local Name, FCI, other localizations (DE, SK), ...
    public List<ImageInfo> Images { get; set; } = new List<ImageInfo>();
    public string? Origin { get; set; }
    public List<string>? Roles { get; set; }
    public string? Size { get; set; }
    public List<string>? NotableDogs { get; set; }
    public List<string>? CelebrityOwners { get; set; }
    public List<string>? HistoricalFacts { get; set; }
    public List<string>? FunFacts { get; set; }
}
