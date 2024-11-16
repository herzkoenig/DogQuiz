﻿using DogQuiz.Data.Entities.Bases;
using DogQuiz.Data.Entities.Breeds;
using DogQuiz.Data.Entities.General;
using DogQuiz.Data.Entities.Questionnaire;
using DogQuiz.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Answer> Answers => Set<Answer>();
    public DbSet<Breed> Breeds => Set<Breed>();
    public DbSet<BreedMix> BreedMixes => Set<BreedMix>();
    public DbSet<BreedName> BreedNames => Set<BreedName>();
    public DbSet<BreedRole> BreedRoles => Set<BreedRole>();
    public DbSet<BreedVariety> BreedVarieties => Set<BreedVariety>();
    public DbSet<Fact> Facts => Set<Fact>();
    public DbSet<ImageDetail> ImageDetails => Set<ImageDetail>();
    public DbSet<NotableDog> NotableDogs => Set<NotableDog>();
    public DbSet<NotableOwner> NotableOwners => Set<NotableOwner>();
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<TagGroup> TagGroups => Set<TagGroup>();

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // MODEL: Breed
        modelBuilder.Entity<Breed>(entity =>
        {
            entity.Property(b => b.Name).IsRequired(); // Required: Breed.Name
            entity.HasIndex(b => b.Name)
                .IsUnique();
        });

        // MODEL: Fact
        //modelBuilder.Entity<Fact>(entity =>
        //{
        //    entity.Property(bf => bf.Breed).IsRequired(); // Required: BreedFact.BreedId
        //    entity.Property(bf => bf.Content).IsRequired(); // Required: BreedFact.Content
        //});

        modelBuilder.Entity<Question>()
        .HasOne(q => q.Answer)
        .WithOne(a => a.Question)
        .HasForeignKey<Answer>(a => a.Id)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Answer>()
            .HasDiscriminator<string>("AnswerType")
            .HasValue<AnswerBoolean>("TrueFalse")
            .HasValue<AnswerText>("Test");

        //modelBuilder.Entity<BreedMix>()
        //    .HasMany(bm => bm.Breeds)
        //    .WithMany();

        modelBuilder.Entity<BreedMix>()
               .HasMany(bm => bm.Breeds)
               .WithMany(b => b.BreedMixes) // Ensure this navigation property exists in Breed
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

        /* DOESN'T WORK ANYMORE WITH MY NEW BASECLASSES */
        // Apply global query filter for soft delete on entities inheriting from AuditableEntityWithSoftDelete
        //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        //{
        //    if (typeof(AuditableEntityWithSoftDelete).IsAssignableFrom(entityType.ClrType))
        //    {
        //        // Build lambda expression for the query filter: e => !e.IsDeleted
        //        var parameter = Expression.Parameter(entityType.ClrType, "e");
        //        var property = Expression.Property(parameter, nameof(AuditableEntityWithSoftDelete.IsDeleted));
        //        var filter = Expression.Lambda(Expression.Not(property), parameter);

        //        modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
        //    }
        //}

        // Loop through each entity type in the model
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            // Loop through each property in the entity
            foreach (var property in entityType.GetProperties())
            {
                // Check if the property type is an enum
                if (property.ClrType.IsEnum)
                {
                    // Apply the conversion to store enums as strings
                    modelBuilder.Entity(entityType.ClrType)
                                .Property(property.Name)
                                .HasConversion<string>();
                }
            }
        }

        /* DOESN'T WORK ANYMORE WITH MY NEW BASECLASSES */
        //modelBuilder.ApplySoftDeleteFilter();
        //modelBuilder.ConvertEnumsToStrings();
    }

    /* DOESN'T WORK WITH THE POOLING THAT IS SET UP WITH ASPIRE */
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    base.OnConfiguring(optionsBuilder);

    //    //// Hacky logging to Console!
    //    optionsBuilder.LogTo(Console.WriteLine);

    //}
}