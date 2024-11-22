namespace DogQuiz.Domain.Exceptions;

public class AggregateStateException : DomainException
{
	public AggregateStateException() : base("An aggregate state violation occurred.") { }
	public AggregateStateException(string message) : base(message)
	{
	}

	public AggregateStateException(string message, Exception innerException) : base(message, innerException)
	{
	}
}
