using DogQuiz.Data.Entities.Bases;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Data.Entities.Breeds;

public class BreedCollection : IBreedCollection
{
    public int Id { get; set; }
    public string? CollectionName { get; set; }
    public ICollection<Breed> Breeds { get; } = new List<Breed>();
    public ICollection<BreedVariety> BreedVarieties { get; } = new List<BreedVariety>();
    public ICollection<BreedMix> BreedMixes { get; } = new List<BreedMix>();


    internal class BreedCollectionConfiguration : IEntityTypeConfiguration<BreedCollection>
    {
        public void Configure(EntityTypeBuilder<BreedCollection> builder)
        {
        }
    }
}