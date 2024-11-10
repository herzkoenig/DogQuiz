using DogQuiz.Server.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DogQuiz.Server.Models;

public class Breed
{
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public ICollection<BreedName> AlternativeNames { get; } = new List<BreedName>();
    public ImageInfo? PrimaryImage { get; set; }
    public ICollection<ImageInfo> AdditionalImages { get; } = new List<ImageInfo>();
    public ICollection<BreedVariety> Varieties { get; } = new List<BreedVariety>();
    public string? Description { get; set; }
    public string? Origin { get; set; }
    public ICollection<TextQuestion> QuizQuestions { get; } = new List<TextQuestion>();
    public ICollection<BreedFact> Facts { get; } = new List<BreedFact>();
    public ICollection<BreedRole> Roles { get; } = new List<BreedRole>();
    public ICollection<NotableDog> NotableDogs { get; } = new List<NotableDog>();
    public ICollection<NotableOwners> NotableOwners { get; } = new List<NotableOwners>();
    // public int? Difficulty { get; set; }
    // public ICollection<BreedTags> Tags { get; set; } = new List<string>();

    /* 
 
    Maybe create a base class AuditableEntity and extend the class with properties like:

        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public ICollection<string> Tags { get; set; } = new List<string>();
        public bool IsActive { get; set; } = true;
        public bool IsVerified { get; set; } = false;
        public int Version { get; set; } = 1;
        public string? Notes { get; set; }

     */
}

