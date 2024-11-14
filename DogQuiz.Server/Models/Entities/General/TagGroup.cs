using DogQuiz.Server.Models.Bases;

namespace DogQuiz.Server.Models.Entities.General;

public class TagGroup : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Tag> Tags { get; } = new List<Tag>();
}
