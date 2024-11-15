using DogQuiz.API.Models.Bases;
using DogQuiz.API.Models.Entities.General;

namespace DogQuiz.API.Models.Entities.Breeds;

public class BreedMix : AuditableEntityWithSoftDelete
{
	public int Id { get; set; }
	public ICollection<Breed> Breeds { get; set; } = [];
	public ICollection<ImageDetail> Images { get; set; } = [];
}
