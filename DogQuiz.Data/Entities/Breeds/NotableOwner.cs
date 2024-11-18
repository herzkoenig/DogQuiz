using DogQuiz.Data.Entities.Bases;
using DogQuiz.Data.Entities.General;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DogQuiz.Data.Configurations;

namespace DogQuiz.Data.Entities.Breeds;

public class NotableOwner : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? KnownFor { get; set; }
    public string? Description { get; set; }
    public ImageDetail? PrimaryImage { get; set; }
    public ICollection<ImageDetail> AdditionalImages { get; } = new List<ImageDetail>();
    // TODO: make it normal again?
    //public BreedCollection? BreedCollection { get; set; }


    internal class NotableOwnerConfiguration : IEntityTypeConfiguration<NotableOwner>
    {
        public void Configure(EntityTypeBuilder<NotableOwner> builder)
        {
            builder.Property(no => no.Name)
                .HasMaxLength(LengthConstants.NameMediumLength);

            builder.Property(no => no.KnownFor)
                .HasMaxLength(LengthConstants.KnownForLength);

            builder.Property(no => no.Description)
                .HasMaxLength(LengthConstants.DescriptionMediumLength);
        }
    }
}