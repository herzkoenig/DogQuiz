using DogQuiz.Data.Configurations;
using DogQuiz.Data.Entities.Bases;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Data.Entities.General;

public class ImageDetail : AuditableEntity
{
    public int Id { get; set; }
    public string? Folder { get; set; }
    public string? FileName { get; set; }
    public string FilePath => Path.Combine(Folder ?? "", FileName ?? "");
    public string? Attribution { get; set; }
    public string? License { get; set; }

    internal class ImageDetailConfiguration : IEntityTypeConfiguration<ImageDetail>
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