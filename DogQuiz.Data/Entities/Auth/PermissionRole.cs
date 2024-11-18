using DogQuiz.Data.Configurations;
using DogQuiz.Data.Entities.Bases;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Data.Entities.Auth;

public class PermissionRole
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Permission> Permissions { get; } = new List<Permission>();
    public ICollection<User> Users { get; } = new List<User>();

    internal class PermissionRoleConfiguration : IEntityTypeConfiguration<PermissionRole>
    {
        public void Configure(EntityTypeBuilder<PermissionRole> builder)
        {
            builder.Property(pr => pr.Name)
                .HasMaxLength(LengthConstants.NameMediumLength);

            builder.Property(pr => pr.Description)
                .HasMaxLength(LengthConstants.DescriptionShortLength);

            builder
                .HasMany(pr => pr.Permissions)
                .WithMany(p => p.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "PermissionRolePermission", // Junction table name
                    j => j
                        .HasOne<Permission>()
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade), // Cascade to delete relationships when a Permission is removed
                    j => j
                        .HasOne<PermissionRole>()
                        .WithMany()
                        .HasForeignKey("PermissionRoleId")
                        .OnDelete(DeleteBehavior.Cascade), // Cascade to delete relationships when a PermissionRole is removed
                    j => {
                        j.HasKey("PermissionId", "PermissionRoleId");
                    });
        }
    }
}
