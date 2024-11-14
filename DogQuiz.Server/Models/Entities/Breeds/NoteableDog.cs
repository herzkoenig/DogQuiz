﻿using DogQuiz.Server.Models.Bases;
using DogQuiz.Server.Models.Entities.General;

namespace DogQuiz.Server.Models.Entities.Breeds;

public class NotableDog : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? KnownFor { get; set; }
    public string? Description { get; set; }
    public ImageDetail? PrimaryImage { get; set; }
    public ICollection<ImageDetail> AdditionalImages { get; } = new List<ImageDetail>();
    public Breed? Breed { get; set; }
    public BreedVariety? BreedVariety { get; set; }
    public BreedMix? BreedMix { get; set; }
}