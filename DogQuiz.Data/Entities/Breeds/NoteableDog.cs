using DogQuiz.Data.Entities.Bases;
using DogQuiz.Data.Entities.General;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Data.Entities.Breeds;

public class NotableDog : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? KnownFor { get; set; }
    public string? Description { get; set; }
    public ImageDetail? PrimaryImage { get; set; }
    public ICollection<ImageDetail> AdditionalImages { get; } = new List<ImageDetail>();
    public Breed? Breed { get; set; }
    public BreedVariety? BreedVariety { get; set; }
    public BreedMix? BreedMix { get; set; }


    internal class NotableDogConfiguration : IEntityTypeConfiguration<NotableDog>
    {
        public void Configure(EntityTypeBuilder<NotableDog> builder)
        {
        }
    }
}