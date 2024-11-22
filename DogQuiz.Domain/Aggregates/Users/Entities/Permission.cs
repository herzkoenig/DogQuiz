using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DogQuiz.Domain.Aggregates.General;

namespace DogQuiz.Domain.Aggregates.Users.Entities;

public class Permission
{
	public int Id { get; set; }
	public required string Name { get; set; }
	public string? Description { get; set; }
	public ICollection<PermissionRole> Roles { get; set; } = new List<PermissionRole>();
	public string? Category { get; set; }
	public required User User { get; set; }

	public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
	{
		public void Configure(EntityTypeBuilder<Permission> builder)
		{
			builder.HasIndex(p => p.Name).IsUnique();

			builder.Property(p => p.Name)
				.HasMaxLength(LengthConstants.NameMediumLength);

			builder.Property(p => p.Description)
				.HasMaxLength(LengthConstants.DescriptionShortLength);

			builder.Property(p => p.Category)
				.HasMaxLength(LengthConstants.NameMediumLength);

			builder
				.HasMany(p => p.Roles)
				.WithMany(pr => pr.Permissions)
				.UsingEntity<Dictionary<string, object>>(
					"PermissionRolePermission", // Matches the table defined in PermissionRoleConfiguration
					j => j
						.HasOne<PermissionRole>()
						.WithMany()
						.HasForeignKey("PermissionRoleId")
						.OnDelete(DeleteBehavior.Cascade),
					j => j
						.HasOne<Permission>()
						.WithMany()
						.HasForeignKey("PermissionId")
						.OnDelete(DeleteBehavior.Cascade),
					j =>
					{
						j.HasKey("PermissionId", "PermissionRoleId");
					});

			builder
				.HasOne(p => p.User)
				.WithMany(u => u.SpecialPermission)
				.HasForeignKey("UserId")
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
