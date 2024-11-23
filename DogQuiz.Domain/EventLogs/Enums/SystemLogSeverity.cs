namespace DogQuiz.Domain.EventLogs.Enums;

[Flags]
public enum SystemLogSeverity
{
	Info = 1,
	Warning = 2,
	Error = 4,
	Critical = 8
}