namespace DogQuiz.Server.Models;

public class BreedName
{
    public int Id { get; set; }
    public int BreedId { get; set; }
    public int? BreedVarietyId { get; set; }
    public required string Name { get; set; }
    public Breed? Breed { get; set; }
    public BreedVariety? BreedVariety { get; set; }
}