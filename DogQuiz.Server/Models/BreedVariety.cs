namespace DogQuiz.Server.Models;

public class BreedVariety
{
    public int Id { get; set; }
    public int BreedId { get; set; }
    public required string Name { get; set; }
    public Breed Breed { get; set; }
    /* Pictures ? */
    /* BreedName ? */

}