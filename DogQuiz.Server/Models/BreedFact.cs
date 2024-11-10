﻿using DogQuiz.Server.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DogQuiz.Server.Models;

public class BreedFact
{
    public int Id { get; set; }
    public int BreedId { get; set; }
    public FactType Type { get; set; }
    public string Content { get; set; }
    public Breed Breed { get; set; }
}