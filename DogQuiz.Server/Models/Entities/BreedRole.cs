using DogQuiz.Server.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DogQuiz.Server.Models.Entities
{
    public class BreedRole
    {
        public int Id { get; set; }
        public BreedRoleType Role { get; set; }
    }
}
