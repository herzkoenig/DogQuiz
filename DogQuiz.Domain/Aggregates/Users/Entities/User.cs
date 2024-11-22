using DogQuiz.Domain.Aggregates.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogQuiz.Domain.Aggregates.Users.Entities;

public class User
{
	public int Id { get; set; }
	public required string IdentityProviderId { get; set; }
	public required string Username { get; set; }
	public required string Email { get; set; }
	public bool IsActive { get; set; } = true;
	public required PermissionRole Role { get; set; }
	public ICollection<Permission> SpecialPermission { get; } = new List<Permission>();
	// Profile Picture !


	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasIndex(u => u.Email).IsUnique();
			builder.HasIndex(u => u.Username).IsUnique();

			builder.Property(u => u.IdentityProviderId)
				.HasMaxLength(LengthConstants.IdentityProviderId);

			builder.Property(u => u.Username)
				.HasMaxLength(LengthConstants.UserNameLength);
			// Configure Min-Length via Constrains?

			builder.Property(u => u.Email)
				.HasMaxLength(LengthConstants.NameMediumLength);

			builder
				.HasOne(u => u.Role)
				.WithMany(r => r.Users)
				.HasForeignKey("RoleId")
				.OnDelete(DeleteBehavior.Restrict); // Restrict to avoid cascading deletions of Users when a Role is deleted

			builder
				.HasMany(u => u.SpecialPermission)
				.WithOne(p => p.User)
				.OnDelete(DeleteBehavior.Restrict); // Restrict to maintain permissions integrity
		}
	}
}