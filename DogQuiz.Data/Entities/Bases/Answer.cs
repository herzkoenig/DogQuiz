using DogQuiz.Data.Entities.Questionnaire;
using DogQuiz.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogQuiz.Data.Entities.Bases;
public abstract class Answer : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public AnswerType Type { get; set; }
    public required Question Question { get; set; }

    internal class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasDiscriminator<string>("AnswerType")
                .HasValue<AnswerTrueFalse>(AnswerType.TrueFalse.ToString())
                .HasValue<AnswerText>(AnswerType.Text.ToString());
        }
    }
}
