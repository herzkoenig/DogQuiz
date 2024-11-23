using DogQuiz.Domain.EventLogs.Bases;
using DogQuiz.Domain.EventLogs.Enums;
using System.Text.Json;

namespace DogQuiz.Domain.EventLogs.Entities;

public class SystemLog : EventLog
{
	//public required string ErrorMessage { get; set; } = string.Empty;
	public string? StackTrace { get; set; }
	public string? Source { get; set; }
	public required SystemLogSeverity Severity { get; set; } = SystemLogSeverity.Info;
	public SystemLogType Type { get; set; } = SystemLogType.System;
	public Dictionary<string, string>? Metadata { get; set; } // JSON
}


//modelBuilder.Entity<SystemLog>()
//    .Property(sl => sl.Metadata)
//    .HasConversion(
//        v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
//        v => JsonSerializer.Deserialize<Dictionary<string, string>>(v, (JsonSerializerOptions?)null)
//    );