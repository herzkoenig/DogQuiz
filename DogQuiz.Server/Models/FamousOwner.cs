using System.ComponentModel.DataAnnotations;

namespace DogQuiz.Server.Models;

public class FamousOwner
{
    public int Id { get; set; }
    public int BreedId { get; set; }
    public Breed Breed { get; set; }
}