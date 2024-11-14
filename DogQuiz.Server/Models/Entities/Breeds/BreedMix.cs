using DogQuiz.Server.Models.Bases;
using DogQuiz.Server.Models.Entities.General;

namespace DogQuiz.Server.Models.Entities.Breeds;

public class BreedMix : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public ICollection<Breed> Breeds { get; set; } = new List<Breed>();
    public ICollection<ImageDetail> Images { get; set; } = new List<ImageDetail>();
}
