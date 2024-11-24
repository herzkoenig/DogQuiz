namespace DogQuiz.Application.Shared.DTOs;

public class GetCountryDto
{
	public string Name { get; set; }
	public string? TwoLetterCode { get; set; }
	public string? ThreeLetterCode { get; set; }
	public string? NumericCode { get; set; }
}
