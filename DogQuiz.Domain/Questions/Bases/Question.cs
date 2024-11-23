using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DogQuiz.Domain.Questions.Entities;
using DogQuiz.Domain.Questions.Enums;
using DogQuiz.Domain.Shared.Bases;
using DogQuiz.Domain.Shared.Constants;
using DogQuiz.Domain.Breeds.Entities;

namespace DogQuiz.Domain.Questions.Bases;

public abstract class Question : AuditableEntityWithSoftDelete
{
	public int Id { get; set; }
	public string? Title { get; set; }
	public string? Text { get; set; }
	public required QuestionType QuestionType { get; set; }
	public int? Difficulty { get; set; }
	public Breed? Breed { get; set; }
	public BreedMix? BreedMix { get; set; }
	public BreedVariety? BreedVariety { get; set; }
	public NotableDog? NotableDog { get; set; }
	public NotableOwner? NotableOwner { get; set; }
	public AnswerType AnswerType => Answer?.Type ?? AnswerType.Unknown;
	public required Answer Answer { get; set; }


	public class QuestionConfiguration : IEntityTypeConfiguration<Question>
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

			builder
			 .HasDiscriminator<QuestionType>("QuestionType")
			 .HasValue<QuestionGeneral>(QuestionType.General)
			 .HasValue<QuestionImage>(QuestionType.Image)
			 .HasValue<QuestionText>(QuestionType.Text);
		}
	}
}