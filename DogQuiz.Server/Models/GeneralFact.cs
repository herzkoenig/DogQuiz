namespace DogQuiz.Server.Models;

public class GeneralFact : AuditableEntity
{
    /* TODO */
    public int Id { get; set; }
    public string? Title { get; set; }
    public required string Content { get; set; }
    public string? Source { get; set; }
}
