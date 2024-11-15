using DogQuiz.API.Models.Entities.Auth;

namespace DogQuiz.API.Models.Bases;

public abstract class AuditableEntityWithSoftDelete : AuditableEntity
{
	public bool IsDeleted { get; set; }
	public DateTime? DateDeleted { get; set; }
	public User? DeletedBy { get; set; }
}
