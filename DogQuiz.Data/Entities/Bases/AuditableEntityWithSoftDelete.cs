using DogQuiz.Data.Entities.Auth;

namespace DogQuiz.Data.Entities.Bases;

public abstract class AuditableEntityWithSoftDelete : AuditableEntity
{
    public bool IsDeleted { get; set; }
    public DateTime? DateDeleted { get; set; }
    public User? DeletedBy { get; set; }
}
