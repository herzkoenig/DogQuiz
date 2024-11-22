using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DogQuiz.Domain.Aggregates.General;
using DogQuiz.Domain.Aggregates.General.Bases;

namespace DogQuiz.Domain.Aggregates.Breeds.Entities;

public class BreedName : AuditableEntityWithSoftDelete
{
	public int Id { get; set; }
	public required string Name { get; set; }
	public Breed? Breed { get; set; }
	public BreedVariety? BreedVariety { get; set; }
	//public BreedMix? BreedMix { get; set; }


	public class BreedNameConfiguration : IEntityTypeConfiguration<BreedName>
	{
		public void Configure(EntityTypeBuilder<BreedName> builder)
		{
			builder.Property(bn => bn.Name)
				.HasMaxLength(LengthConstants.NameMediumLength);
		}
	}
}