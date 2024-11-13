using DogQuiz.Server.Models.Base;
using DogQuiz.Server.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DogQuiz.Server.Models.Entities;

public class Fact : AuditableEntity
{
    public int Id { get; set; }
    public int? BreedId { get; set; }
    public FactType Type { get; set; }
    public required string Content { get; set; }
    public Breed? Breed { get; set; }
}