using DogQuiz.Data.Entities.Bases;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Data.Entities.Breeds;

public class BreedName : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public Breed? Breed { get; set; }
    public BreedVariety? BreedVariety { get; set; }


    internal class BreedNameConfiguration : IEntityTypeConfiguration<BreedName>
    {
        public void Configure(EntityTypeBuilder<BreedName> builder)
        {
        }
    }
}