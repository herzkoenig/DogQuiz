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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure a unique index on the Name property of the Breed entity
        modelBuilder.Entity<Breed>()
            .HasIndex(b => b.Name)
            .IsUnique();

    }
}
