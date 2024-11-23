using DogQuiz.Domain.Questions.Bases;
using DogQuiz.Domain.Shared.Bases;
using DogQuiz.Domain.Shared.Constants;
using DogQuiz.Domain.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogQuiz.Domain.Breeds.Entities;

public class BreedMix : AuditableEntityWithSoftDelete, IQuestionHolder
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public string? Description { get; set; }
	public ImageDetail? PrimaryImage { get; set; }
	public ICollection<ImageDetail> Images { get; } = new List<ImageDetail>();
	public ICollection<Breed> Breeds { get; } = new List<Breed>();
	public ICollection<Question> Questions { get; } = new List<Question>();


	public class BreedMixConfiguration : IEntityTypeConfiguration<BreedMix>
	{
		public void Configure(EntityTypeBuilder<BreedMix> builder)
		{
			builder
				.HasMany(bm => bm.Breeds)
				.WithMany(b => b.Mixes)
				.UsingEntity<Dictionary<string, object>>(
					"BreedBreedMix", // Name of the join table
					j => j
						.HasOne<Breed>()
						.WithMany()
						.HasForeignKey("BreedId")
						.OnDelete(DeleteBehavior.Cascade),
					j => j
						.HasOne<BreedMix>()
						.WithMany()
						.HasForeignKey("BreedMixId")
						.OnDelete(DeleteBehavior.Cascade)
				);

			builder.Property(bm => bm.Name)
				.HasMaxLength(LengthConstants.NameMediumLength);

			builder.Property(bm => bm.Description)
				.HasMaxLength(LengthConstants.DescriptionMediumLength);
		}
	}
}


