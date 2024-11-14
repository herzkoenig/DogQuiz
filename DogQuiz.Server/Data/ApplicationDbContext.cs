using DogQuiz.Server.Models.Bases;
using DogQuiz.Server.Models.Entities.Auth;
using DogQuiz.Server.Models.Entities.Breeds;
using DogQuiz.Server.Models.Entities.General;
using DogQuiz.Server.Models.Entities.Questionnaire;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DogQuiz.Server.Data;

public class ApplicationDbContext : IdentityDbContext<User>
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

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
: base(options)
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
        modelBuilder.Entity<Fact>(entity =>
        {
            entity.Property(bf => bf.BreedId).IsRequired(); // Required: BreedFact.BreedId
            entity.Property(bf => bf.Content).IsRequired(); // Required: BreedFact.Content
        });

        // MODEL: TextAnswer
        modelBuilder.Entity<AnswerBoolean>(entity =>
        {
            entity.Property(a => a.QuestionId).IsRequired(); // Required: TextAnswer.QuestionId
        });

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        //// Hacky logging to Console!
        //optionsBuilder.LogTo(Console.WriteLine);

    }
}
