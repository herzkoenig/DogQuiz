using System.ComponentModel.DataAnnotations;

namespace DogQuiz.Server.Models;

public class BreedVariety
{
    public int Id { get; set; }
    public int BreedId { get; set; }
    public Breed Breed { get; set; }
}