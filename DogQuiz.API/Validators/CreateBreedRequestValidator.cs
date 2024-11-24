//using FluentValidation;

//namespace DogQuiz.API.Validators;
//public class CreateBreedRequestValidator : AbstractValidator<CreateBreedRequest>
//{
//	public CreateBreedRequestValidator()
//	{
//		RuleFor(x => x.Name)
//			.NotEmpty().WithMessage("Breed name is required.")
//			.MaximumLength(100).WithMessage("Breed name cannot exceed 100 characters.");

//		RuleFor(x => x.Description)
//			.MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters.");

//		RuleFor(x => x.Difficulty)
//			.InclusiveBetween(1, 5).WithMessage("Difficulty must be between 1 and 5.")
//			.When(x => x.Difficulty.HasValue);

//		RuleForEach(x => x.AdditionalNames)
//			.MaximumLength(100).WithMessage("Each additional name cannot exceed 100 characters.");

//		//RuleForEach(x => x.BreedTags)
//		//	.NotEmpty().WithMessage("Tags cannot be empty.");
//	}
//}
