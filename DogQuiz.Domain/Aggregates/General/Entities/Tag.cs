using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DogQuiz.Domain.Aggregates.General;
using DogQuiz.Domain.Aggregates.General.Bases;
using DogQuiz.Domain.Aggregates.General.Enums;

namespace DogQuiz.Domain.Aggregates.General.Entities;

public class Tag : AuditableEntityWithSoftDelete
{
	public int Id { get; set; }
	public required string Name { get; set; }
	public TagType Type { get; set; } = TagType.General;


	public class TagConfiguration : IEntityTypeConfiguration<Tag>
	{
		public void Configure(EntityTypeBuilder<Tag> builder)
		{
			builder.HasIndex(t => t.Name).IsUnique();

			builder.Property(t => t.Name)
				.HasMaxLength(LengthConstants.TagNameLength);
		}
	}
}
