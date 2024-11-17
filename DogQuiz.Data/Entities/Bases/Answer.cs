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


    internal class AnswerConfigurator : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            // All enum members have to be written down here like that...
            // TODO: Look for another solution, preferably without reflection, if that is possible.
            builder.HasDiscriminator<string>("AnswerType")
                .HasValue<AnswerTrueFalse>(AnswerType.TrueFalse.ToString())
                .HasValue<AnswerText>(AnswerType.Text.ToString());
        }
    }
}
