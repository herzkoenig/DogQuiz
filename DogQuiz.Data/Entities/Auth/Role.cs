using DogQuiz.Data.Entities.Bases;

namespace DogQuiz.Data.Entities.Auth;

public class Role
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Permission> Permissions { get; } = new List<Permission>();
    public ICollection<User> Users { get; } = new List<User>();
}
