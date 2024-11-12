using DogQuiz.Server.Models.Auditing;

namespace DogQuiz.Server.Models.Entities;

public class ImageDetail : AuditableEntity
{
    public string? Folder { get; set; }
    public string? FileName { get; set; }
    public string FilePath => Path.Combine(Folder ?? "", FileName ?? "");
    public string? Attribution { get; set; }
    public string? License { get; set; }
}

/*
 
    public int? Width { get; set; }
    public int? Height { get; set; }
    public long? FileSize { get; set; }
    public string? Format { get; set; }
    public string? AltText { get; set; }
    public List<string>? BreedTags { get; set; }
    public bool IsPrimary { get; set; }
    public string? UsageContext { get; set; }

    Updated, Navigation Properties, ... ?

*/