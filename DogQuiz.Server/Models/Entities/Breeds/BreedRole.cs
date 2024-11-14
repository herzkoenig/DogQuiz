using DogQuiz.Server.Models.Bases;
using DogQuiz.Server.Models.Enums;

namespace DogQuiz.Server.Models.Entities.Breeds
{
    public class BreedRole : AuditableEntityWithSoftDelete
    {
        public int Id { get; set; }
        public required BreedRoleType Role { get; set; }
        public required Breed Breed { get; set; }
    }
}
