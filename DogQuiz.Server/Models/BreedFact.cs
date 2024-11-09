using DogQuiz.Server.Models.Enums;

namespace DogQuiz.Server.Models;

public class BreedFact
{
    public string Content { get; set; }
    public FactType Type { get; set; }
}