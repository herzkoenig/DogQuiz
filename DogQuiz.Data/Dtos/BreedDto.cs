namespace DogQuiz.Data.Dtos;

public class BreedDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<string> AlternativeNames { get; set; } = [];
    //public ImageInfoDto? PrimaryImage { get; set; }
    //public List<ImageInfoDto> AdditionalImages { get; set; } = new List<ImageInfoDto>();
    public List<string> Varieties { get; set; } = [];
    public string? Description { get; set; }
    public string? Origin { get; set; }
    public List<string> QuizQuestions { get; set; } = [];
    public List<string> Facts { get; set; } = [];
    public List<string> Roles { get; set; } = [];
    public List<string> NotableDogs { get; set; } = [];
    public List<string> NotableOwners { get; set; } = [];

}