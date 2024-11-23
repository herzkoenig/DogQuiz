using System.Security.Cryptography;
using System.Text;

namespace DogQuiz.Domain.Questions.Services;

public class CorrectAnswer
{
	public string HashedValue { get; private set; }

	private CorrectAnswer(string hashedValue)
	{
		HashedValue = hashedValue;
	}

	public static CorrectAnswer Create(string plainAnswer)
	{
		if (string.IsNullOrWhiteSpace(plainAnswer))
		{
			throw new ArgumentException("Answer cannot be empty");
		}
		return new CorrectAnswer(Hash(plainAnswer));
	}

	private static string Hash(string answer)
	{
		using (var sha256 = SHA256.Create())
		{
			var bytes = Encoding.UTF8.GetBytes(answer);
			var hash = sha256.ComputeHash(bytes);
			return Convert.ToBase64String(hash);
		}
	}

	public bool Validate(string plainAnswer)
	{
		return HashedValue == Hash(plainAnswer);
	}

}