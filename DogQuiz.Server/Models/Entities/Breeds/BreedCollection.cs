using DogQuiz.Server.Models.Bases;
using DogQuiz.Server.Services.Interfaces;

namespace DogQuiz.Server.Models.Entities.Breeds
{
    public class BreedCollection : IBreedCollection
    {
        public int Id { get; set; }
        public string? CollectionName { get; set; }
        public ICollection<Breed> Breeds { get; } = new List<Breed>();
        public ICollection<BreedVariety> BreedVarieties { get; } = new List<BreedVariety>();
        public ICollection<BreedMix> BreedMixes { get; } = new List<BreedMix>();
    }
}
