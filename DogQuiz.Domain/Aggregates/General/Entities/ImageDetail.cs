using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DogQuiz.Domain.Aggregates.General;
using DogQuiz.Domain.Aggregates.General.Bases;

namespace DogQuiz.Domain.Aggregates.General.Entities;

public class ImageDetail : AuditableEntity
{
	public int Id { get; set; }
	public string? Folder { get; set; }
	public string? FileName { get; set; }
	public string FilePath => Path.Combine(Folder ?? "", FileName ?? "");
	public string? Attribution { get; set; }
	public string? License { get; set; }
	//public User? UploadedBy { get; set; }


	public class ImageDetailConfiguration : IEntityTypeConfiguration<ImageDetail>
	{
		public void Configure(EntityTypeBuilder<ImageDetail> builder)
		{
			builder.Property(i => i.Folder)
				.HasMaxLength(LengthConstants.ImageFolderPathLength);

			builder.Property(i => i.FileName)
				.HasMaxLength(LengthConstants.ImageFileNameLength);

			builder.Property(i => i.Attribution)
				.HasMaxLength(LengthConstants.ImageAttributionLength);

			builder.Property(i => i.License)
				.HasMaxLength(LengthConstants.ImageLicenseLength);
		}
	}
}