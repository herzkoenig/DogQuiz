namespace DogQuiz.Server.Models.Entities;

public class Tag
{
    public int Id { get; set; }
    public int GroupId { get; set; }
    public required string Name { get; set; }
    public TagGroup Group { get; set; }
}
