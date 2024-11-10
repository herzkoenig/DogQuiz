using System.ComponentModel.DataAnnotations;

namespace DogQuiz.Server.Models;

public class BreedVariety
{
    [Required]
    public Breed AssociatedBreed { get; set; }
}