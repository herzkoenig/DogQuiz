using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogQuiz.Domain.Shared.Entities;

public class Country
{
	public int Id { get; set; }
	public required string Name { get; set; }
	public string? TwoLetterCode { get; set; }
	public string? ThreeLetterCode { get; set; }
	public string? NumericCode { get; set; }
}