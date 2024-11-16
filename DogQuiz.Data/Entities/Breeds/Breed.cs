﻿using DogQuiz.Data.Entities.Bases;
using DogQuiz.Data.Entities.General;
using DogQuiz.Data.Entities.Questionnaire;

namespace DogQuiz.Data.Entities.Breeds;

public class Breed : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<BreedName> AdditionalNames { get; } = [];
    public ImageDetail? Image { get; set; }
    public ICollection<ImageDetail> AdditionalImages { get; } = [];
    public ICollection<BreedVariety> Varieties { get; } = [];
    public ICollection<BreedMix> BreedMixes { get; } = [];
    public string? Description { get; set; }
    public string? Origin { get; set; }
    public int? Difficulty { get; set; }
    public ICollection<Question> Questions { get; } = [];
    public ICollection<BreedRole> Roles { get; } = [];
    public ICollection<Fact> Facts { get; } = [];
    public ICollection<NotableDog> NotableDogs { get; } = [];
    public ICollection<NotableOwner> NotableOwners { get; } = [];
    public ICollection<Tag> BreedTags { get; } = [];
}