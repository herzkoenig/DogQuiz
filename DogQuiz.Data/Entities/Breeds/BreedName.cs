﻿using DogQuiz.Data.Entities.Bases;

namespace DogQuiz.Data.Entities.Breeds;

public class BreedName : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public Breed? Breed { get; set; }
    public BreedVariety? BreedVariety { get; set; }

}