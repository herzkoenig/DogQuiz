using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DogQuiz.Domain.Aggregates.Breeds.Entities;
using DogQuiz.Domain.Aggregates.Questions.Enums;
using DogQuiz.Domain.Aggregates.General;
using DogQuiz.Domain.Aggregates.General.Bases;

namespace DogQuiz.Domain.Aggregates.Questions.Entities;

// Model Fact as a Question?

public class Fact : AuditableEntityWithSoftDelete
{
	public int Id { get; set; }
	public FactType Type { get; set; }
	public required string Content { get; set; }
	public Breed? Breed { get; set; }

	public class FactConfiguration : IEntityTypeConfiguration<Fact>
	{
		public void Configure(EntityTypeBuilder<Fact> builder)
		{
			builder.Property(f => f.Content)
				.HasMaxLength(LengthConstants.DescriptionShortLength);
		}
	}
}