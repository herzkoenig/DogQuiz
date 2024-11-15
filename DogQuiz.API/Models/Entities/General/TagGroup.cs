using DogQuiz.API.Models.Bases;

namespace DogQuiz.API.Models.Entities.General;

public class TagGroup : AuditableEntityWithSoftDelete
{
	public int Id { get; set; }
	public required string Name { get; set; }
	public ICollection<Tag> Tags { get; } = [];
}
