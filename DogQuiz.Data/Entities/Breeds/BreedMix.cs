using DogQuiz.Data.Entities.Bases;
using DogQuiz.Data.Entities.General;

namespace DogQuiz.Data.Entities.Breeds;

public class BreedMix : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public ICollection<Breed> Breeds { get; set; } = [];
    public ICollection<ImageDetail> Images { get; set; } = [];
}
