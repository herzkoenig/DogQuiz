using DogQuiz.Server.Models.Auditing;
using DogQuiz.Server.Models.Auth;

namespace DogQuiz.Server.Models.Entities;

public class ImageDetail : AuditableEntity
{
    public int Id { get; set; }
    public string? Folder { get; set; }
    public string? FileName { get; set; }
    public string FilePath => Path.Combine(Folder ?? "", FileName ?? "");
    public string? Attribution { get; set; }
    public string? License { get; set; }
}