﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DogQuiz.Domain.Aggregates.Questions.Bases;
using DogQuiz.Domain.Aggregates.Questions.Entities;
using DogQuiz.Domain.Aggregates.General;
using DogQuiz.Domain.Aggregates.General.Bases;
using DogQuiz.Domain.Aggregates.General.Entities;
using DogQuiz.Domain.Aggregates.Breeds.Validation;

namespace DogQuiz.Domain.Aggregates.Breeds.Entities;

public class Breed : AuditableEntityWithSoftDelete, IQuestionHolder
{

	public int Id { get; set; }
	public required string Name { get; set; }
	public ICollection<BreedName> AdditionalNames { get; } = new List<BreedName>();
	public ImageDetail? Image { get; set; }
	public ICollection<ImageDetail> AdditionalImages { get; } = new List<ImageDetail>();
	public ICollection<BreedVariety> Varieties { get; } = new List<BreedVariety>();
	public ICollection<BreedMix> Mixes { get; } = new List<BreedMix>();
	public ICollection<NotableDog> NotableDogs { get; } = new List<NotableDog>();
	public ICollection<NotableOwner> NotableOwners { get; } = new List<NotableOwner>();
	public string? Description { get; set; }
	public BreedOrigin? Origin { get; set; }
	public int? Difficulty { get; set; }
	public ICollection<BreedRole> Roles { get; } = new List<BreedRole>();
	public ICollection<Question> Questions { get; } = new List<Question>();
	public ICollection<Fact> Facts { get; } = new List<Fact>();
	public ICollection<Tag> BreedTags { get; } = new List<Tag>();

	public Breed(string name, string? description = null, int? difficulty = null)
	{
		Name = name;
		Description = description;
		Difficulty = difficulty;
	}


	private void SetName(string name)
	{
		BreedValidation.ValidateName(name);
		Name = name;
	}

	private void SetDescription(string? description)
	{
		BreedValidation.ValidateDescription(description);
		Description = description;
	}

	private void SetDifficulty(int? difficulty)
	{
		BreedValidation.ValidateDifficulty(difficulty);
		Difficulty = difficulty;
	}

	public void AddFact(Fact fact)
	{
		BreedValidation.ValidateFact(fact);
		Facts.Add(fact);
	}
	public class BreedConfiguration : IEntityTypeConfiguration<Breed>
	{
		public void Configure(EntityTypeBuilder<Breed> builder)
		{
			builder.Property(b => b.Name)
				.HasMaxLength(LengthConstants.NameMediumLength);

			builder.HasIndex(b => b.Name).IsUnique();

			builder.Property(b => b.Description)
				.HasMaxLength(LengthConstants.DescriptionMediumLength);
		}
	}
}