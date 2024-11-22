using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogQuiz.Domain.Exceptions;

public abstract class DomainException : Exception
{
	protected DomainException() : base("A domain exception has occurred.") { }
	protected DomainException(string message) : base(message) { }
	protected DomainException(string message, Exception innerException) : base(message, innerException) { }
}