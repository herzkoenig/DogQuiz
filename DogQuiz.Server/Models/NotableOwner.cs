namespace DogQuiz.Server.Models;

public class NotableOwner : AuditableEntity
{
    public int Id { get; set; }
    public int BreedId { get; set; }
    public string? Name { get; set; }
    public string? KnownFor { get; set; }
    public string? Description { get; set; }
    public ImageDetail? PrimaryImage { get; set; }
    public ICollection<ImageDetail> AdditionalImages { get; } = new List<ImageDetail>();
    public Breed Breed { get; set; }
}