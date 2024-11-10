using DogQuiz.Server.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DogQuiz.Server.Models;

public class BreedName
{
    public int Id { get; set; }
    public int BreedId { get; set; }
    public int BreedVarietyId { get; set; }
    public Breed Breed { get; set; }
    public BreedVariety BreedVariety { get; set; } = null;
    public string Name { get; set; }
    public bool IsPrimary { get; set; } = false;
}