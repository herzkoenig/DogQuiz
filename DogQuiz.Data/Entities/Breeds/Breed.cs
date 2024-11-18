﻿// STATUS: ...

using DogQuiz.Data.Entities.Bases;
using DogQuiz.Data.Entities.General;
using DogQuiz.Data.Entities.Questionnaire;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DogQuiz.Data.Configurations;

namespace DogQuiz.Data.Entities.Breeds;

public class Breed : AuditableEntityWithSoftDelete, IQuestionable
{
    public int Id { get; set; } 
    public required string Name { get; set; }
    public ICollection<BreedName> AdditionalNames { get; } = new List<BreedName>();
    public ImageDetail? Image { get; set; }
    public ICollection<ImageDetail> AdditionalImages { get; } = new List<ImageDetail>();
    public ICollection<BreedVariety> Varieties { get; } = new List<BreedVariety>();
    public ICollection<BreedMix> Mixes { get; } = new List<BreedMix>();
    public string? Description { get; set; }
    public string? Origin { get; set; }
    public int? Difficulty { get; set; }
    public ICollection<Question> Questions { get; } = new List<Question>();
    public ICollection<BreedRole> Roles { get; } = new List<BreedRole>();
    public ICollection<Fact> Facts { get; } = new List<Fact>();
    public ICollection<NotableDog> NotableDogs { get; } = new List<NotableDog>();
    public ICollection<NotableOwner> NotableOwners { get; } = new List<NotableOwner>();
    public ICollection<Tag> BreedTags { get; } = new List<Tag>();

    // ?: Difficulty Range 1-10
    internal class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.Property(b => b.Name)
                .HasMaxLength(LengthConstants.NameMediumLength)
                .IsRequired();

            builder.HasIndex(b => b.Name).IsUnique();

            builder.Property(b => b.Description)
                .HasMaxLength(LengthConstants.DescriptionMediumLength);

            builder.Property(b => b.Origin)
                .HasMaxLength(LengthConstants.OriginLength);
        }
    }
}