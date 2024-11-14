using DogQuiz.Server.Models.Entities.Auth;

namespace DogQuiz.Server.Models.Bases;

public abstract class AuditableEntityWithSoftDelete : AuditableEntity
{
    public bool IsDeleted { get; set; }
    public DateTime? DateDeleted { get; set; }
    public User? DeletedBy { get; set; }
    //public string? DeletedById { get; set; }
}
