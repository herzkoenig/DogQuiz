using DogQuiz.Data.Entities.Bases;

namespace DogQuiz.Data.Entities.Auth;

public class User
{
    public int Id { get; set; }
    public required string IdentityProviderId { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public bool IsActive { get; set; } = true;
    public required PermissionRole Role { get; set; }
    public ICollection<Permission> SpecialPermission { get; } = new List<Permission>();
}