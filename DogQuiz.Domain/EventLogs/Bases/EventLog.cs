using DogQuiz.Domain.Users.Entities;

namespace DogQuiz.Domain.EventLogs.Bases;

public abstract class EventLog
{
	public int Id { get; set; }
	public User? User { get; set; }
	public DateTime OccurredAt { get; set; } = DateTime.UtcNow;
	public string? Message { get; set; }
}


