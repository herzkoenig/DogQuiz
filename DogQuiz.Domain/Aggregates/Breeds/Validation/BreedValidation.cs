namespace DogQuiz.Domain.Aggregates.Breeds.Validation;

public static class BreedValidation
{
	public static void ValidateName(string name)
	{
		if (string.IsNullOrWhiteSpace(name))
			throw new ArgumentException("Breed name is required.", nameof(name));

		if (name.Length > 100)
			throw new ArgumentException("Breed name cannot exceed 100 characters.", nameof(name));
	}

	public static void ValidateDescription(string? description)
	{
		if (description != null && description.Length > 1000)
			throw new ArgumentException("Description cannot exceed 1000 characters.", nameof(description));
	}

	public static void ValidateDifficulty(int? difficulty)
	{
		if (difficulty.HasValue && (difficulty < 1 || difficulty > 5))
			throw new ArgumentOutOfRangeException(nameof(difficulty), "Difficulty must be between 1 and 5.");
	}

	public static void ValidateFact(object fact)
	{
		if (fact == null)
			throw new ArgumentNullException(nameof(fact), "Fact cannot be null.");
	}

	public static void ValidateBreedId(int id)
	{
		if (id <= 0)
			throw new ArgumentException("Breed ID must be greater than zero.");
	}
}
