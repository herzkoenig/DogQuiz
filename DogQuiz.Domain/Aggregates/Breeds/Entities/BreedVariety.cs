using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DogQuiz.Domain.Aggregates.Questions.Bases;
using DogQuiz.Domain.Aggregates.General;
using DogQuiz.Domain.Aggregates.General.Bases;
using DogQuiz.Domain.Aggregates.General.Entities;

namespace DogQuiz.Domain.Aggregates.Breeds.Entities;

public class BreedVariety : AuditableEntityWithSoftDelete, IQuestionHolder
{
	public int Id { get; set; }
	public required string Name { get; set; }
	public required Breed Breed { get; set; }
	public ICollection<Tag> Tags { get; } = new List<Tag>();
	public ICollection<Question> Questions { get; } = new List<Question>();


	public class BreedVarietyConfiguration : IEntityTypeConfiguration<BreedVariety>
	{
		public void Configure(EntityTypeBuilder<BreedVariety> builder)
		{
			builder.HasIndex(bv => bv.Name).IsUnique();

			builder.Property(bv => bv.Name)
				.HasMaxLength(LengthConstants.NameMediumLength);
		}
	}
}