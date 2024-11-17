using DogQuiz.Data.Entities.Bases;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Data.Entities.Breeds;

public class BreedVariety : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required Breed Breed { get; set; }


    internal class BreedVarietyConfiguration : IEntityTypeConfiguration<BreedVariety>
    {
        public void Configure(EntityTypeBuilder<BreedVariety> builder)
        {
        }
    }
}