namespace DogQuiz.Server.Models.Auditing;

public abstract class AuditableEntityWithSoftDelete : AuditableEntity
{
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOn { get; set; }
    public string DeletedBy { get; set; }
}
