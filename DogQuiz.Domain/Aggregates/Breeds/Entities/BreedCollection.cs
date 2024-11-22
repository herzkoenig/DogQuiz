using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DogQuiz.Domain.Aggregates.General;
using DogQuiz.Domain.Aggregates.General.Bases;

namespace DogQuiz.Domain.Aggregates.Breeds.Entities;

public class BreedCollection : AuditableEntityWithSoftDelete
{
	public int Id { get; set; }
	public required string Name { get; set; }
	public ICollection<Breed> Breeds { get; } = new List<Breed>();
	public ICollection<BreedVariety> BreedVarieties { get; } = new List<BreedVariety>();
	public ICollection<BreedMix> BreedMixes { get; } = new List<BreedMix>();


	public class BreedCollectionConfiguration : IEntityTypeConfiguration<BreedCollection>
	{
		public void Configure(EntityTypeBuilder<BreedCollection> builder)
		{
			builder.Property(bc => bc.Name)
				.HasMaxLength(LengthConstants.NameLongLength);
		}
	}
}