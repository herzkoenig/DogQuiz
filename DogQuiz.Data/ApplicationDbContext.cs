using DogQuiz.Data.Entities.Auth;
using DogQuiz.Data.Entities.Bases;
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
    public DbSet<User> Users { get; set; }
    public DbSet<PermissionRole> PermissionRoles { get; set; }
    public DbSet<Permission> Permissions { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new Breed.BreedConfiguration());
        modelBuilder.ApplyConfiguration(new BreedCollection.BreedCollectionConfiguration());
        modelBuilder.ApplyConfiguration(new BreedMix.BreedMixConfiguration());
        modelBuilder.ApplyConfiguration(new BreedName.BreedNameConfiguration());
        modelBuilder.ApplyConfiguration(new BreedRole.BreedRoleConfiguration());
        modelBuilder.ApplyConfiguration(new BreedVariety.BreedVarietyConfiguration());
        modelBuilder.ApplyConfiguration(new NotableOwner.NotableOwnerConfiguration());
        modelBuilder.ApplyConfiguration(new NotableDog.NotableDogConfiguration());

        // Store Enums as Strings
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType.IsEnum)
                {
                    modelBuilder.Entity(entityType.ClrType)
                                .Property(property.Name)
                                .HasConversion<string>();
                }
            }
        }

        // https://blog.jetbrains.com/dotnet/2023/06/14/how-to-implement-a-soft-delete-strategy-with-entity-framework-core/

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
}
