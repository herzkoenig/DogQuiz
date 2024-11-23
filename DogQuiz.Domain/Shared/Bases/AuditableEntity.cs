using DogQuiz.Domain.Users.Entities;
using System.ComponentModel.DataAnnotations;

namespace DogQuiz.Domain.Shared.Bases;

public abstract class AuditableEntity
{
	public DateTime DateCreated { get; set; } = DateTime.UtcNow;
	public User? CreatedBy { get; set; }
	public DateTime? DateUpdated { get; set; }
	public User? UpdatedBy { get; set; }
	// READ: https://learn.microsoft.com/en-us/ef/core/saving/concurrency?tabs=data-annotations
	[Timestamp]
	public byte[]? RowVersion { get; set; }
}