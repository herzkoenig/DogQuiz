namespace DogQuiz.Domain.Exceptions;

public class ConsistencyException : DomainException
{
	public ConsistencyException() : base("A consistency issue occurred.")
	{
	}
	public ConsistencyException(string message) : base(message) { }
	public ConsistencyException(string message, Exception innerException) : base(message, innerException) { }
}