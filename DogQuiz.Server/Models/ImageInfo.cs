using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Server.Models;

public class ImageInfo
{
    public string? Folder { get; set; }
    public string? FileName { get; set; }
    public string FilePath => Path.Combine(Folder ?? "", FileName ?? "");
    public string? Attribution { get; set; }
    public string? License { get; set; }
}

/*

    public string? Folder { get; set; }
    public string? FileName { get; set; }
    public string? Attribution { get; set; }
    public string? License { get; set; }
    public string? FilePath => Path.Combine(Folder ?? "", FileName ?? "");
    public int? Width { get; set; }
    public int? Height { get; set; }
    public long? FileSize { get; set; }
    public DateTime? DateUploaded { get; set; }
    public string? Format { get; set; }
    public string? AltText { get; set; }
    public List<string>? Tags { get; set; }
    public bool IsPrimary { get; set; }
    public string? UsageContext { get; set; }
    public int? BreedVarietyId { get; set; }  // foreign key reference
    public int DogId { get; set; } // Foreign key to Dog
    public Dog Dog { get; set; }   // Navigation property

*/