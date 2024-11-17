using DogQuiz.Data.Entities.Bases;
using DogQuiz.Data.Entities.General;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Data.Entities.Breeds;

public class NotableOwner : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? KnownFor { get; set; }
    public string? Description { get; set; }
    public ImageDetail? PrimaryImage { get; set; }
    public ICollection<ImageDetail> AdditionalImages { get; } = new List<ImageDetail>();
    public BreedCollection? BreedCollection { get; set; }


    internal class NotableOwnerConfiguration : IEntityTypeConfiguration<NotableOwner>
    {
        public void Configure(EntityTypeBuilder<NotableOwner> builder)
        {
        }
    }
}