using DogQuiz.Server.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DogQuiz.Server.Models;

public class BreedFact
{
    [Required]
    public Breed AssociatedBreed { get; set; }
    [Required]
    public string Content { get; set; }
    [Required]
    public FactType Type { get; set; }
}