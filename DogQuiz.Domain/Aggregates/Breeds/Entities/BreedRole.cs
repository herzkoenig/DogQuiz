using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DogQuiz.Domain.Aggregates.Breeds.Enums;
using DogQuiz.Domain.Aggregates.General;
using DogQuiz.Domain.Aggregates.General.Bases;

namespace DogQuiz.Domain.Aggregates.Breeds.Entities;

public class BreedRole : AuditableEntityWithSoftDelete
{
	public int Id { get; set; }
	public required BreedRoleType Role { get; set; }
	public required Breed Breed { get; set; }


	public class BreedRoleConfiguration : IEntityTypeConfiguration<BreedName>
	{
		public void Configure(EntityTypeBuilder<BreedName> builder)
		{
			builder.Property(br => br.Name)
				.HasMaxLength(LengthConstants.NameMediumLength);
		}
	}
}