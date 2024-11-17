using DogQuiz.Data.Dtos;
using DogQuiz.Data.Entities.Bases;
using DogQuiz.Data.Entities.Questionnaire;
using Riok.Mapperly.Abstractions;

namespace DogQuiz.Data.Mappings;


[Mapper]
public partial class QuestionMapper
{
    public partial QuestionDto MapToQuestionDto(Question question);
    public partial QuestionDetailDto MapToQuestionDetailDto(Question question);
    public partial QuestionDetailDto MapToQuestionDetailDto(QuestionImage questionImage);
    public partial QuestionDetailDto MapToQuestionDetailDto(QuestionText questionText);

}