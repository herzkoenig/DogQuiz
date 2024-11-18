using DogQuiz.Data.Entities.Bases;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DogQuiz.Data.Configurations;

namespace DogQuiz.Data.Entities.Breeds;

public class BreedCollection : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Breed> Breeds { get; } = new List<Breed>();
    public ICollection<BreedVariety> BreedVarieties { get; } = new List<BreedVariety>();
    public ICollection<BreedMix> BreedMixes { get; } = new List<BreedMix>();


    internal class BreedCollectionConfiguration : IEntityTypeConfiguration<BreedCollection>
    {
        public void Configure(EntityTypeBuilder<BreedCollection> builder)
        {
            builder.Property(bc => bc.Name)
                .HasMaxLength(LengthConstants.NameLongLength);
        }
    }
}