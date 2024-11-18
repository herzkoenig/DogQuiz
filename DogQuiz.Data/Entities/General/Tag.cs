using DogQuiz.Data.Configurations;
using DogQuiz.Data.Entities.Bases;
using DogQuiz.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Data.Entities.General;

public class Tag : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    //public int TagGroupId { get; set; }
    public required string Name { get; set; }
    public TagType Type { get; set; } = TagType.General;
    public required TagGroup Group { get; set; }

    internal class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasIndex(t => t.Name).IsUnique();

            builder.Property(t => t.Name)
                .HasMaxLength(LengthConstants.TagNameLength);
        }
    }
}
