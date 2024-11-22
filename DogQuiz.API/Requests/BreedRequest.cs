using DogQuiz.Domain.Aggregates.Breeds.Entities;
using DogQuiz.Domain.Aggregates.General.Entities;
using Riok.Mapperly.Abstractions;

namespace DogQuiz.API.Requests;

public class CreateBreedRequest
{
	public required string Name { get; set; }
	public List<string> AdditionalNames { get; set; } = new();
	public string? Description { get; set; }
	public int? Difficulty { get; set; }
	public List<string> BreedTags { get; set; } = new();
}

public class UpdateBreedRequest
{
	public required int Id { get; set; }
	public string? Name { get; set; }
	public List<string>? AdditionalNames { get; set; }
	public string? Description { get; set; }
	public int? Difficulty { get; set; }
	public List<string>? BreedTags { get; set; }
}

[Mapper]
public static partial class BreedRequestMapper
{
	[MapperIgnoreTarget(nameof(Breed.Id))]
	[MapperIgnoreTarget(nameof(Breed.CreatedBy))]
	[MapperIgnoreTarget(nameof(Breed.UpdatedBy))]
	[MapperIgnoreTarget(nameof(Breed.DeletedBy))]
	[MapperIgnoreTarget(nameof(Breed.DateCreated))]
	[MapperIgnoreTarget(nameof(Breed.DateUpdated))]
	[MapperIgnoreTarget(nameof(Breed.DateDeleted))]
	[MapperIgnoreTarget(nameof(Breed.RowVersion))]
	[MapperIgnoreTarget(nameof(Breed.IsDeleted))]
	[MapperIgnoreTarget(nameof(Breed.Origin))]
	[MapperIgnoreTarget(nameof(Breed.Image))]
	public static Breed ToBreed(this CreateBreedRequest request)
	{
		// Use the explicit constructor to initialize required properties
		var breed = new Breed(request.Name, request.Description, request.Difficulty) { Name = request.Name };

		// Populate additional names
		foreach (var additionalName in request.AdditionalNames)
		{
			breed.AdditionalNames.Add(new BreedName { Name = additionalName });
		}

		// Populate tags
		foreach (var tag in request.BreedTags)
		{
			breed.BreedTags.Add(new Tag { Name = tag });
		}

		return breed;
	}

	[MapperIgnoreTarget(nameof(Breed.CreatedBy))]
	[MapperIgnoreTarget(nameof(Breed.UpdatedBy))]
	[MapperIgnoreTarget(nameof(Breed.DeletedBy))]
	[MapperIgnoreTarget(nameof(Breed.DateCreated))]
	[MapperIgnoreTarget(nameof(Breed.DateUpdated))]
	[MapperIgnoreTarget(nameof(Breed.DateDeleted))]
	[MapperIgnoreTarget(nameof(Breed.RowVersion))]
	[MapperIgnoreTarget(nameof(Breed.IsDeleted))]
	[MapperIgnoreTarget(nameof(Breed.Origin))]
	[MapperIgnoreTarget(nameof(Breed.Image))]
	public static void UpdateBreedFromRequest(this UpdateBreedRequest request, Breed breed)
	{
		if (request.Name is not null)
			breed.Name = request.Name;

		if (request.Description is not null)
			breed.Description = request.Description;

		if (request.Difficulty.HasValue)
			breed.Difficulty = request.Difficulty;

		if (request.AdditionalNames is not null)
		{
			breed.AdditionalNames.Clear();
			foreach (var additionalName in request.AdditionalNames)
			{
				breed.AdditionalNames.Add(new BreedName { Name = additionalName });
			}
		}

		if (request.BreedTags is not null)
		{
			breed.BreedTags.Clear();
			foreach (var tag in request.BreedTags)
			{
				breed.BreedTags.Add(new Tag { Name = tag });
			}
		}
	}
}