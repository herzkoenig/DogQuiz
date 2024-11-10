using DogQuiz.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Server.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    public DbSet<Breed> Breeds => Set<Breed>();
    public DbSet<GeneralFact> GeneralFacts => Set<GeneralFact>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<ImageInfo>()
            .HasKey(i => new { i.Folder, i.FileName }); // Composite primary key configuration

        // Configure one-to-many relationship between Breed and BreedNames
        modelBuilder.Entity<Breed>()
            .HasMany(b => b.AlternativeNames)
            .WithOne(bn => bn.Breed)
            .HasForeignKey(bn => bn.BreedId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete to avoid cycle

        // Configure any other relationships as necessary
        modelBuilder.Entity<BreedName>()
            .HasOne(bn => bn.BreedVariety)
            .WithMany() // Adjust based on your model's relationships
            .HasForeignKey(bn => bn.BreedVarietyId)
            .OnDelete(DeleteBehavior.Restrict); // Restrict delete to prevent cascade issues



        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {


        // Hacky logging to Console!
        optionsBuilder.LogTo(Console.WriteLine);
        base.OnConfiguring(optionsBuilder);
    }
}
