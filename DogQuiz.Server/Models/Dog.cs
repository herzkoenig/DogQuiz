using System.ComponentModel.DataAnnotations;

namespace DogQuiz.Server.Models;

public class Dog
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string? BreedName{ get; set; }
    public string? BreedNameLocal { get; set; }
    public string? BreedNameFCI { get; set; }
    [Required]
    public string? ImageUrl { get; set; }
    public string? History { get; set; }
    public string? FunFacts { get; set; }
}
