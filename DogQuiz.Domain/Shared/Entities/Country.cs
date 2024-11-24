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

	public Country(string name, string? twoLetterCode, string? threeLetterCode, string? numericCode)
	{
		Name = name;
		TwoLetterCode = twoLetterCode;
		ThreeLetterCode = threeLetterCode;
		NumericCode = numericCode;
	}
}
