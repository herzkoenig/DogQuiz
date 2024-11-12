namespace DogQuiz.Server.Models.Entities;

public class TagGroup
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
