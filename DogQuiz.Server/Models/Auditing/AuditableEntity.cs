using DogQuiz.Server.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DogQuiz.Server.Models.Auditing;

public abstract class AuditableEntity
{
    public DateTime DateAdded { get; set; }
    public DateTime? DateUpdated { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    //[Timestamp]
    //public byte[] TimeStamp { get; set; }
}