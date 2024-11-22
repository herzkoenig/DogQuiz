using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DogQuiz.Domain.Aggregates.General;
using DogQuiz.Domain.Aggregates.General.Bases;
using DogQuiz.Domain.Aggregates.General.Entities;

namespace DogQuiz.Domain.Aggregates.Breeds.Entities;

public class NotableDog : AuditableEntityWithSoftDelete
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public string? KnownFor { get; set; }
	public string? Description { get; set; }
	public ImageDetail? PrimaryImage { get; set; }
	public ICollection<ImageDetail> AdditionalImages { get; } = new List<ImageDetail>();
	public Breed? Breed { get; set; }
	public BreedVariety? BreedVariety { get; set; }
	public BreedMix? BreedMix { get; set; }


	public class NotableDogConfiguration : IEntityTypeConfiguration<NotableDog>
	{
		public void Configure(EntityTypeBuilder<NotableDog> builder)
		{
			builder.Property(nd => nd.Name)
				.HasMaxLength(LengthConstants.NameMediumLength);

			builder.Property(nd => nd.KnownFor)
				.HasMaxLength(LengthConstants.KnownForLength);

			builder.Property(nd => nd.Description)
				.HasMaxLength(LengthConstants.DescriptionMediumLength);
		}
	}
}