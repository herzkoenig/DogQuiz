using DogQuiz.Data.Configurations;
using DogQuiz.Data.Entities.Bases;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Data.Entities.General;

public class TagGroup : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Tag> Tags { get; } = new List<Tag>();

    internal class TagGroupConfiguration : IEntityTypeConfiguration<TagGroup>
    {
        public void Configure(EntityTypeBuilder<TagGroup> builder)
        {
            builder.HasIndex(tg => tg.Name).IsUnique();

            builder.Property(tg => tg.Name)
                .HasMaxLength(LengthConstants.TagGroupNameLength);
        }
    }
}
