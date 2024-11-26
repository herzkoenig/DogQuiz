using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DogQuiz.Domain.Shared.Bases;
using DogQuiz.Domain.Shared.Enums;
using DogQuiz.Domain.Shared.Constants;

namespace DogQuiz.Domain.Shared.Entities;

public class Tag : AuditableEntityWithSoftDelete
{
	public int Id { get; set; }
	public string Name { get; set; }
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
