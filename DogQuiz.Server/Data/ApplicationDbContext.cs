using DogQuiz.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Server.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    public DbSet<Dog> Dogs => Set<Dog>();
}
