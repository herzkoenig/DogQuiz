using DogQuiz.Server.Models.Entities;
using DogQuiz.Server.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Server.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Answer> Answers => Set<Answer>();
    public DbSet<Breed> Breeds => Set<Breed>();
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
        // MODEL: Breed
        modelBuilder.Entity<Breed>(entity =>
        {
            entity.Property(b => b.Name).IsRequired(); // Required: Breed.Name

            /* Not needed, changed to string Name, but leave it here for reference */
            //entity.HasMany(b => b.AdditionalNames) // One-to-many: Breed to BreedName
            //      .WithOne(bn => bn.Breed)
            //      .HasForeignKey(bn => bn.BreedId)
            //      .OnDelete(DeleteBehavior.Restrict); // Restrict delete to prevent cycle
        });

        // MODEL: BreedFact
        modelBuilder.Entity<Fact>(entity =>
        {
            entity.Property(bf => bf.BreedId).IsRequired(); // Required: BreedFact.BreedId
            entity.Property(bf => bf.Content).IsRequired(); // Required: BreedFact.Text
        });

        /* Not needed, changed to string Name, but leave it here for reference */
        //// MODEL: BreedName
        //modelBuilder.Entity<BreedName>()
        //    .HasOne(bn => bn.BreedVariety) // Foreign key: BreedName to BreedVariety
        //    .WithMany()
        //    .HasForeignKey(bn => bn.BreedVarietyId)
        //    .OnDelete(DeleteBehavior.Restrict); // Restrict delete to prevent issues

        // MODEL: ImageDetail
        modelBuilder.Entity<ImageDetail>()
            .HasKey(i => new { i.Folder, i.FileName }); // Composite key for ImageDetail
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Hacky logging to Console!
        optionsBuilder.LogTo(Console.WriteLine);
        base.OnConfiguring(optionsBuilder);
    }
}
