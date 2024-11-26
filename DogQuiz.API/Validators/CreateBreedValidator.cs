using DogQuiz.Application.Shared.DTOs;
using FluentValidation;
using DogQuiz.Domain.Shared.Constants;

namespace DogQuiz.API.Validators;
public class CreateBreedValidator : AbstractValidator<CreateBreedDto>
{
	public CreateBreedValidator()
	{
		RuleFor(dto => dto.Name)
			.NotEmpty().WithMessage("Breed name is required.")
			.Length(3, LengthConstants.NameMediumLength)
			.WithMessage($"Breed name must be between 3 and {LengthConstants.NameMediumLength} characters.");

		RuleFor(dto => dto.Description)
			.MaximumLength(LengthConstants.DescriptionMediumLength)
			.WithMessage($"Description cannot exceed {LengthConstants.DescriptionMediumLength} characters.")
			.When(dto => !string.IsNullOrEmpty(dto.Description));
	}
}
