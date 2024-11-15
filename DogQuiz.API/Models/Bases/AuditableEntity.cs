using DogQuiz.API.Models.Entities.Auth;

namespace DogQuiz.API.Models.Bases;

public abstract class AuditableEntity
{
	public DateTime DateCreated { get; set; } = DateTime.UtcNow;
	public User? CreatedBy { get; set; }
	public DateTime? DateUpdated { get; set; }
	public User? UpdatedBy { get; set; }
}