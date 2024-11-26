using DogQuiz.Application.Shared.DTOs;
using DogQuiz.Domain.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Riok.Mapperly.Abstractions;

namespace DogQuiz.Application.Shared.Mappers;

[Mapper]
public static partial class CountryMapper
{
	public static partial Country ToCountry(GetCountryDto dto);
	public static partial GetCountryDto ToGetCountryDto(Country country);
}