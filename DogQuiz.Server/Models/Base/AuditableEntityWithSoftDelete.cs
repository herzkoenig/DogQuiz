using DogQuiz.Server.Models.Auth;

namespace DogQuiz.Server.Models.Base;

public abstract class AuditableEntityWithSoftDelete : AuditableEntity
{
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOn { get; set; }
    public User? DeletedBy { get; set; }
}
