using System.Security.Cryptography;
using System.Text;

namespace DogQuiz.Domain.Aggregates.Questions.Services;

public class HashingService
{
	public string Hash(string input)
	{
		using (var sha256 = SHA256.Create())
		{
			var bytes = Encoding.UTF8.GetBytes(input);
			var hash = sha256.ComputeHash(bytes);
			return Convert.ToBase64String(hash);
		}
	}

	public bool Validate(string input, string hashedValue)
	{
		return Hash(input) == hashedValue;
	}
}
