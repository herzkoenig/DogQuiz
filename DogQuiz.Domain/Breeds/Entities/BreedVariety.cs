using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DogQuiz.Domain.Questions.Bases;
using DogQuiz.Domain.Shared.Bases;
using DogQuiz.Domain.Shared.Entities;
using DogQuiz.Domain.Shared.Constants;

namespace DogQuiz.Domain.Breeds.Entities;

public class BreedVariety : AuditableEntityWithSoftDelete, IQuestionHolder
{
	public int Id { get; set; }
	public string Name { get; set; }
	public Breed Breed { get; set; }
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