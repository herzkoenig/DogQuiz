namespace DogQuiz.Server.Models.Auditing;

public class ChangeLog
{
    public int Id { get; set; }
    public string EntityName { get; set; }
    public string EntityId { get; set; }
    public string PropertyName { get; set; }
    public string OldValue { get; set; }
    public string NewValue { get; set; }
    public DateTime ChangedOn { get; set; }
    public string ChangedBy { get; set; }
}
