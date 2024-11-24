using DogQuiz.Domain.Breeds.Entities;
using DogQuiz.Domain.Users.Entities;
using System.ComponentModel.DataAnnotations;

namespace DogQuiz.Domain.Shared.Entities;

public class Country
{
	public int Id { get; set; }
	[Required]
	public string Name { get; set; }
	public string? TwoLetterCode { get; set; }
	public string? ThreeLetterCode { get; set; }
	public string? NumericCode { get; set; }
	public ICollection<BreedOrigin> BreedOrigins { get; } = new List<BreedOrigin>();
	public ICollection<User> Users { get; } = new List<User>();


	public Country(string name, string? twoLetterCode, string? threeLetterCode, string? numericCode)
	{
		Name = name;
		TwoLetterCode = twoLetterCode;
		ThreeLetterCode = threeLetterCode;
		NumericCode = numericCode;
	}
}
