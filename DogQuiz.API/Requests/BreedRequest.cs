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
	public static partial Breed ToBreed(this CreateBreedRequest request);
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
	public static partial void UpdateBreedFromRequest(this UpdateBreedRequest request, Breed breed);

#pragma warning disable IDE0051
	private static Tag MapToTag(string tag) => new() { Name = tag };
	private static BreedName MapToBreedName(string name) => new() { Name = name };
#pragma warning restore
}

