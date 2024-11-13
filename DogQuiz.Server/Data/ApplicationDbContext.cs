using DogQuiz.Server.Models.Auth;
using DogQuiz.Server.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Server.Data;

public class ApplicationDbContext : IdentityDbContext<User>
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
        base.OnModelCreating(modelBuilder);

        // MODEL: Breed
        modelBuilder.Entity<Breed>(entity =>
        {
            entity.Property(b => b.Name).IsRequired(); // Required: Breed.Name
        });

        // MODEL: Fact
        modelBuilder.Entity<Fact>(entity =>
        {
            entity.Property(bf => bf.BreedId).IsRequired(); // Required: BreedFact.BreedId
            entity.Property(bf => bf.Content).IsRequired(); // Required: BreedFact.Content
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        //// Hacky logging to Console!
        //optionsBuilder.LogTo(Console.WriteLine);

    }
}
