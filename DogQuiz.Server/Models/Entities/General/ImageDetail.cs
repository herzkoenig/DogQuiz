using DogQuiz.Server.Models.Bases;
using DogQuiz.Server.Models.Entities.Breeds;

namespace DogQuiz.Server.Models.Entities.General;

public class ImageDetail : AuditableEntity
{
    public int Id { get; set; }
    public string? Folder { get; set; }
    public string? FileName { get; set; }
    public string FilePath => Path.Combine(Folder ?? "", FileName ?? "");
    public string? Attribution { get; set; }
    public string? License { get; set; }
}