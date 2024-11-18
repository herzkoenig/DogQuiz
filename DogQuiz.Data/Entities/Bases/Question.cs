using DogQuiz.Data.Entities.Breeds;
using DogQuiz.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DogQuiz.Data.Configurations;

namespace DogQuiz.Data.Entities.Bases;

public class Question : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
    public required QuestionType Type { get; set; }
    public int? Difficulty { get; set; }
    public Breed? Breed { get; set; }
    public BreedMix? BreedMix { get; set; }
    public BreedVariety? BreedVariety { get; set; }
    public required Answer Answer { get; set; }


    internal class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(q => q.Title)
                .HasMaxLength(LengthConstants.QuestionTitleLength);

            builder.Property(q => q.Text)
                .HasMaxLength(LengthConstants.QuestionTextLength);

            builder
                .HasOne(q => q.Answer)
                .WithOne(a => a.Question)
                .HasForeignKey<Answer>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}