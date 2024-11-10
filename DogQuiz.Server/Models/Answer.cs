using DogQuiz.Server.Models.Enums;

namespace DogQuiz.Server.Models;

public class Answer
{
    public int Id { get; set; }
    public AnswerType Type { get; set; }
    public string? TextAnswer { get; set; }
    public List<string>? MultipleChoiceAnswers { get; set; }
    public bool? BooleanAnswer { get; set; }
    public List<string>? ListAnswers { get; set; }
}