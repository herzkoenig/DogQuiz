using DogQuiz.Data.Entities.Bases;

namespace DogQuiz.Data.Entities.General;

public class TagGroup : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Tag> Tags { get; } = new List<Tag>();
}
