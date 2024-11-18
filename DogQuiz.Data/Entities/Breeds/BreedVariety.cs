using DogQuiz.Data.Entities.Bases;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DogQuiz.Data.Configurations;

namespace DogQuiz.Data.Entities.Breeds;

public class BreedVariety : AuditableEntityWithSoftDelete, IQuestionable
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required Breed Breed { get; set; }
    public ICollection<Question> Questions { get; } = new List<Question>();


    internal class BreedVarietyConfiguration : IEntityTypeConfiguration<BreedVariety>
    {
        public void Configure(EntityTypeBuilder<BreedVariety> builder)
        {
            builder.HasIndex(bv => bv.Name).IsUnique();

            builder.Property(bv => bv.Name)
                .HasMaxLength(LengthConstants.NameMediumLength);
        }
    }
}