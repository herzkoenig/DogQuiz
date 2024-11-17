using DogQuiz.Data.Entities.Bases;
using DogQuiz.Data.Entities.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogQuiz.Data.Entities.Breeds;

public class BreedMix : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public ICollection<Breed> Breeds { get; set; } = new List<Breed>();
    public ICollection<ImageDetail> Images { get; set; } = new List<ImageDetail>();


    internal class BreedMixConfiguration : IEntityTypeConfiguration<BreedMix>
    {
        public void Configure(EntityTypeBuilder<BreedMix> builder)
        {
            builder
                .HasMany(bm => bm.Breeds)
                .WithMany(b => b.Mixes)
                .UsingEntity<Dictionary<string, object>>(
                    "BreedBreedMix", // Name of the join table
                    j => j
                        .HasOne<Breed>()
                        .WithMany()
                        .HasForeignKey("BreedId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<BreedMix>()
                        .WithMany()
                        .HasForeignKey("BreedMixId")
                        .OnDelete(DeleteBehavior.Cascade)
                );
        }
    }
}