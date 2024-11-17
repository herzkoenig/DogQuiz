using DogQuiz.Data.Entities.Bases;

namespace DogQuiz.Data.Entities.Auth;

public class Permission
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<PermissionRole> Roles { get; set; } = new List<PermissionRole>();
    public string? Category { get; set; }
}
