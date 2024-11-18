using DogQuiz.Data.Configurations;
using DogQuiz.Data.Entities.Bases;
using DogQuiz.Data.Entities.Breeds;
using DogQuiz.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Data.Entities.Questionnaire;

public class Fact : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public FactType Type { get; set; }
    public required string Content { get; set; }
    public Breed? Breed { get; set; }

    internal class FactConfiguration : IEntityTypeConfiguration<Fact>
    {
        public void Configure(EntityTypeBuilder<Fact> builder)
        {
            builder.Property(f => f.Content)
                .HasMaxLength(LengthConstants.DescriptionShortLength);
        }
    }
}