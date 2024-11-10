namespace DogQuiz.Server.Models
{
    public class QuizQuestion
    {
        public int Id { get; set; }
        public int BreedId { get; set; }
        public Breed Breed { get; set; }
    }
}