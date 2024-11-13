namespace DogQuiz.Server.Models.Entities
{
    public class BreedMix
    {
        public int Id { get; set; }
        public ICollection<Breed> Breeds { get; set; } = new List<Breed>();
    }
}
