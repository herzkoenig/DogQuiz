using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DogQuiz.Domain.Questions.Bases;
using DogQuiz.Domain.Shared.Bases;
using DogQuiz.Domain.Shared.Entities;
using DogQuiz.Domain.Shared.Constants;

namespace DogQuiz.Domain.Breeds.Entities;

public class NotableOwner : AuditableEntityWithSoftDelete
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
	public ICollection<Question> Questions { get; set; } = new List<Question>();


	public class NotableOwnerConfiguration : IEntityTypeConfiguration<NotableOwner>
	{
		public void Configure(EntityTypeBuilder<NotableOwner> builder)
		{
			builder.Property(no => no.Name)
				.HasMaxLength(LengthConstants.NameMediumLength);

			builder.Property(no => no.KnownFor)
				.HasMaxLength(LengthConstants.KnownForLength);

			builder.Property(no => no.Description)
				.HasMaxLength(LengthConstants.DescriptionMediumLength);
		}
	}
}