using DogQuiz.Server.Models.Base;
using DogQuiz.Server.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DogQuiz.Server.Models.Entities;

public class Breed : AuditableEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<BreedName> AdditionalNames { get; } = new List<BreedName>();
    public ImageDetail? Image { get; set; }
    public ICollection<ImageDetail> AdditionalImages { get; } = new List<ImageDetail>();
    public ICollection<BreedVariety> Varieties { get; } = new List<BreedVariety>();
    public string? Description { get; set; }
    public string? Origin { get; set; }
    public int? Difficulty { get; set; }
    public ICollection<Question> Questions { get; } = new List<Question>();
    public ICollection<BreedRole> Roles { get; } = new List<BreedRole>();
    public ICollection<Fact> Facts { get; } = new List<Fact>();
    public ICollection<NotableDog> NotableDogs { get; } = new List<NotableDog>();
    public ICollection<NotableOwner> NotableOwners { get; } = new List<NotableOwner>();
    public ICollection<Tag> BreedTags { get; set; } = new List<Tag>();
    // MIXED BREEDS!!
}