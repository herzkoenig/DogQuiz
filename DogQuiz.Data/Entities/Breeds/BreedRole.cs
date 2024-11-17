using DogQuiz.Data.Entities.Bases;
using DogQuiz.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Data.Entities.Breeds;

public class BreedRole : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public required BreedRoleType Role { get; set; }
    public required Breed Breed { get; set; }


    internal class BreedRoleConfiguration : IEntityTypeConfiguration<BreedName>
    {
        public void Configure(EntityTypeBuilder<BreedName> builder)
        {
        }
    }
}