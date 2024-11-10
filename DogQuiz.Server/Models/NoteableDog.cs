namespace DogQuiz.Server.Models;

public class NotableDog
{
    public int Id { get; set; }
    public int BreedId { get; set; }
    public Breed Breed { get; set; }

}