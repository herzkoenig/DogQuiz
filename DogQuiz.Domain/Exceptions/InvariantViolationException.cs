namespace DogQuiz.Domain.Exceptions;

public class InvariantViolationException : DomainException
{
	public InvariantViolationException() : base("An invariant violation occurred.") { }
	public InvariantViolationException(string message) : base(message) { }
	public InvariantViolationException(string message, Exception innerException) : base(message, innerException) { }
}
