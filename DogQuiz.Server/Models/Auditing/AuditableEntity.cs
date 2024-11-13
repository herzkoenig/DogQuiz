using DogQuiz.Server.Models.Auth;

namespace DogQuiz.Server.Models.Auditing;

public abstract class AuditableEntity
{
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public User? CreatedBy { get; set; }
    public DateTime? DateUpdated { get; set; }
    public User? UpdatedBy { get; set; }
}