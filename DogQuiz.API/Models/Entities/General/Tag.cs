using DogQuiz.API.Models.Bases;
using DogQuiz.API.Models.Enums;

namespace DogQuiz.API.Models.Entities.General;

public class Tag : AuditableEntityWithSoftDelete
{
	public int Id { get; set; }
	public int TagGroupId { get; set; }
	public required string Name { get; set; }
	public TagType Type { get; set; } = TagType.General;
	public required TagGroup Group { get; set; }
}
