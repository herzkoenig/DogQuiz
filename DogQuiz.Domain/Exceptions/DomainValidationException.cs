﻿namespace DogQuiz.Domain.Exceptions;

public class DomainValidationException : DomainException
{
	public DomainValidationException(string message) : base(message)
	{
	}
	public DomainValidationException(string message, Exception innerException) : base(message, innerException)
	{
	}
}
