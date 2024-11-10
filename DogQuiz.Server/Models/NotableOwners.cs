namespace DogQuiz.Server.Models;

public class NotableOwners
{
    public int Id { get; set; }
    public int BreedId { get; set; }
    public string? Name { get; set; }
    public string? KnownFor { get; set; }
    public string? Description { get; set; }
    public ImageInfo? PrimaryImage { get; set; }
    public ICollection<ImageInfo> AdditionalImages { get; } = new List<ImageInfo>();
    public Breed Breed { get; set; }
}