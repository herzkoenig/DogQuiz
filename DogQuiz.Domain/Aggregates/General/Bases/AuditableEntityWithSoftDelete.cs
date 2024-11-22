using DogQuiz.Domain.Aggregates.Users.Entities;

namespace DogQuiz.Domain.Aggregates.General.Bases;

public abstract class AuditableEntityWithSoftDelete : AuditableEntity
{
	public bool IsDeleted { get; set; }
	public DateTime? DateDeleted { get; set; }
	public User? DeletedBy { get; set; }

	public void SoftDelete(User user)
	{
		IsDeleted = true;
		DateDeleted = DateTime.UtcNow;
		DeletedBy = user;
	}
}