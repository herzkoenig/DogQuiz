using System.ComponentModel.DataAnnotations;

namespace DogQuiz.Server.Models;

public class FamousOwner
{
    [Required]
    public Breed AssociatedBreed { get; set; }
}