using DogQuiz.Server.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DogQuiz.Server.Models;

public class BreedFact
{
    public int Id { get; set; }
    [Required]
    public int BreedId { get; set; }
    public FactType Type { get; set; }
    public required string Content { get; set; }
    public Breed? Breed { get; set; }
}