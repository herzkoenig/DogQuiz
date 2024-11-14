using DogQuiz.Server.Models.Bases;
using DogQuiz.Server.Models.Enums;

namespace DogQuiz.Server.Models.Entities.General;

public class Tag : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public int TagGroupId { get; set; }
    public required string Name { get; set; }
    public TagType Type { get; set; } = TagType.General;
    public TagGroup Group { get; set; }
}
