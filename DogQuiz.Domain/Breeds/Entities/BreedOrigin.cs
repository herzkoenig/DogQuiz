using DogQuiz.Domain.Shared.Bases;
using DogQuiz.Domain.Shared.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Domain.Breeds.Entities;

public class BreedOrigin
{
	public int Id { get; set; }
	public ICollection<Country> Countries { get; } = new List<Country>();
	public string? Text { get; set; }
	public string? HistoricalContext { get; set; }


	public class BreedOriginConfiguration : IEntityTypeConfiguration<BreedOrigin>
	{
		public void Configure(EntityTypeBuilder<BreedOrigin> builder)
		{
			builder.HasMany(bo => bo.Countries)
				.WithMany(c => c.BreedOrigins);
		}
	}
}