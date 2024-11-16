using DogQuiz.Data.Entities.Bases;
using DogQuiz.Data.Enums;

namespace DogQuiz.Data.Entities.General;

public class Tag : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public int TagGroupId { get; set; }
    public required string Name { get; set; }
    public TagType Type { get; set; } = TagType.General;
    public required TagGroup Group { get; set; }
}
