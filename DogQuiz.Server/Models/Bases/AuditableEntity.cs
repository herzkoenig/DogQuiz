﻿using DogQuiz.Server.Models.Entities.Auth;

namespace DogQuiz.Server.Models.Bases;

public abstract class AuditableEntity
{
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public User? CreatedBy { get; set; }
    public DateTime? DateUpdated { get; set; }
    public User? UpdatedBy { get; set; }
    //public string? CreatedById { get; set; }
    //public string? UpdatedById { get; set; }
}