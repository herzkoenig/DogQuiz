using DogQuiz.Data.Configurations;
using DogQuiz.Data.Entities.Bases;
using DogQuiz.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Data.Entities.Questionnaire;

// integrate in a flat answer table
public class AnswerText : Answer
{
    public AnswerText()
    {
        Type = AnswerType.Text;
    }
    public string? Text { get; set; }

    internal class AnswerTextConfiguration : IEntityTypeConfiguration<AnswerText>
    {
        public void Configure(EntityTypeBuilder<AnswerText> builder)
        {
            builder.Property(at => at.Text)
                .HasMaxLength(LengthConstants.AnswerTextLength);
        }
    }
}