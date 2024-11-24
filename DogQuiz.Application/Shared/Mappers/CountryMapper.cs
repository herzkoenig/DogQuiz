using DogQuiz.Domain.Shared.Entities;
using Riok.Mapperly.Abstractions;

namespace DogQuiz.Application.Shared.DTOs;
[Mapper]
public static partial class CountryMapper
{
	public static partial Country ToCountry(GetCountryDto dto);
	public static partial GetCountryDto ToGetCountryDto(Country country);

}