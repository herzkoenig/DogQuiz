using DogQuiz.Server.Models.Bases;
using DogQuiz.Server.Models.Entities.General;
using DogQuiz.Server.Models.Entities.Questionnaire;

namespace DogQuiz.Server.Models.Entities.Breeds;

public class Breed : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<BreedName> AdditionalNames { get; } = new List<BreedName>();
    public ImageDetail? Image { get; set; }
    public ICollection<ImageDetail> AdditionalImages { get; } = new List<ImageDetail>();
    public ICollection<BreedVariety> Varieties { get; } = new List<BreedVariety>();
    public ICollection<BreedMix> BreedMixes { get; } = new List<BreedMix>();
    public string? Description { get; set; }
    public string? Origin { get; set; }
    public int? Difficulty { get; set; }
    public ICollection<Question> Questions { get; } = new List<Question>();
    public ICollection<BreedRole> Roles { get; } = new List<BreedRole>();
    public ICollection<Fact> Facts { get; } = new List<Fact>();
    public ICollection<NotableDog> NotableDogs { get; } = new List<NotableDog>();
    public ICollection<NotableOwner> NotableOwners { get; } = new List<NotableOwner>();
    public ICollection<Tag> BreedTags { get; } = new List<Tag>();
}