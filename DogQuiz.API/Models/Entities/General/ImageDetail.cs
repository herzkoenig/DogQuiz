using DogQuiz.API.Models.Bases;

namespace DogQuiz.API.Models.Entities.General;

public class ImageDetail : AuditableEntity
{
	public int Id { get; set; }
	public string? Folder { get; set; }
	public string? FileName { get; set; }
	public string FilePath => Path.Combine(Folder ?? "", FileName ?? "");
	public string? Attribution { get; set; }
	public string? License { get; set; }
}