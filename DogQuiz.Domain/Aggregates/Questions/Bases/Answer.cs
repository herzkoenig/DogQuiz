using DogQuiz.Domain.Aggregates.General.Bases;
using DogQuiz.Domain.Aggregates.General.Entities;
using DogQuiz.Domain.Aggregates.Questions.Entities;
using DogQuiz.Domain.Aggregates.Questions.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogQuiz.Domain.Aggregates.Questions.Bases;

public abstract class Answer : AuditableEntityWithSoftDelete
{
	public int Id { get; set; }
	public required Question Question { get; set; }
	public required AnswerType Type { get; set; } = AnswerType.Unknown;
	public string? Title { get; set; }
	public string? Text { get; set; }
	public ImageDetail? Image { get; set; }

	public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
	{
		public void Configure(EntityTypeBuilder<Answer> builder)
		{
			builder.HasDiscriminator<string>("AnswerType")
				.HasValue<AnswerTrueFalse>(AnswerType.TrueFalse.ToString())
				.HasValue<AnswerMultipleSelect>(AnswerType.MultipleSelect.ToString())
				.HasValue<AnswerSingleSelect>(AnswerType.SingleSelect.ToString());
		}
	}
}
