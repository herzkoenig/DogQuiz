using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DogQuiz.Domain.Shared.Bases;
using DogQuiz.Domain.Shared.Constants;
using DogQuiz.Domain.Breeds.Enums;

namespace DogQuiz.Domain.Breeds.Entities;

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