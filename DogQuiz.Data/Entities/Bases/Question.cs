using DogQuiz.Data.Entities.Breeds;
using DogQuiz.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DogQuiz.Data.Entities.Bases;

public class Question : AuditableEntityWithSoftDelete
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
    public required QuestionType Type { get; set; }
    public int? Difficulty { get; set; }
    public Breed? Breed { get; set; }
    public required Answer Answer { get; set; }


    internal class QuestionConfigurator : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(q => q.Title).HasMaxLength(150);

            builder.Property(q => q.Text).HasMaxLength(1000);

            builder.HasOne(q => q.Breed)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade); // TODO: check if correct

            builder.HasOne(q => q.Answer)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); // TODO: check if correct
        }
    }
}