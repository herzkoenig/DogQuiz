using Microsoft.EntityFrameworkCore;
using DogQuiz.Domain.Questions.Bases;
using DogQuiz.Domain.Questions.Entities;
using DogQuiz.Domain.Users.Entities;
using DogQuiz.Domain.Shared.Entities;
using DogQuiz.Domain.Breeds.Entities;
using DogQuiz.Infrastructure.Initialization;

namespace DogQuiz.Infrastructure;

public class ApplicationDbContext : DbContext
{
	public DbSet<Permission> Permissions { get; set; }
	public DbSet<PermissionRole> PermissionRoles { get; set; }
	public DbSet<User> Users { get; set; }
	public DbSet<Breed> Breeds => Set<Breed>();
	//public DbSet<BreedCollection> BreedCollections => Set<BreedCollection>();
	public DbSet<BreedMix> BreedMixes => Set<BreedMix>();
	public DbSet<BreedName> BreedNames => Set<BreedName>();
	public DbSet<BreedOrigin> BreedOrigins => Set<BreedOrigin>();
	public DbSet<BreedRole> BreedRoles => Set<BreedRole>();
	public DbSet<BreedVariety> BreedVarieties => Set<BreedVariety>();
	public DbSet<NotableOwner> NotableOwners => Set<NotableOwner>();
	public DbSet<NotableDog> NotableDogs => Set<NotableDog>();
	public DbSet<ImageDetail> ImageDetails => Set<ImageDetail>();
	public DbSet<Tag> Tags => Set<Tag>();
	public DbSet<Country> Countries => Set<Country>();
	public DbSet<Answer> Answers => Set<Answer>();
	public DbSet<Fact> Facts => Set<Fact>();
	public DbSet<Question> Questions => Set<Question>();

#pragma warning disable CS8618
	public ApplicationDbContext(DbContextOptions options) : base(options)
	{
	}
#pragma warning restore

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		// Users
		modelBuilder.ApplyConfiguration(new Permission.PermissionConfiguration());
		modelBuilder.ApplyConfiguration(new PermissionRole.PermissionRoleConfiguration());
		modelBuilder.ApplyConfiguration(new User.UserConfiguration());
		// Breeds
		modelBuilder.ApplyConfiguration(new Breed.BreedConfiguration());
		//modelBuilder.ApplyConfiguration(new BreedCollection.BreedCollectionConfiguration());
		modelBuilder.ApplyConfiguration(new BreedMix.BreedMixConfiguration());
		modelBuilder.ApplyConfiguration(new BreedName.BreedNameConfiguration());
		modelBuilder.ApplyConfiguration(new BreedOrigin.BreedOriginConfiguration());
		modelBuilder.ApplyConfiguration(new BreedRole.BreedRoleConfiguration());
		modelBuilder.ApplyConfiguration(new BreedVariety.BreedVarietyConfiguration());
		modelBuilder.ApplyConfiguration(new NotableOwner.NotableOwnerConfiguration());
		modelBuilder.ApplyConfiguration(new NotableDog.NotableDogConfiguration());
		// General
		modelBuilder.ApplyConfiguration(new ImageDetail.ImageDetailConfiguration());
		modelBuilder.ApplyConfiguration(new Tag.TagConfiguration());
		// Questionnaire
		modelBuilder.ApplyConfiguration(new Answer.AnswerConfiguration());
		modelBuilder.ApplyConfiguration(new Fact.FactConfiguration());
		modelBuilder.ApplyConfiguration(new Question.QuestionConfiguration());

		// Store Enums as Strings
		foreach (var entityType in modelBuilder.Model.GetEntityTypes())
		{
			foreach (var property in entityType.GetProperties())
			{
				if (property.ClrType.IsEnum)
				{
					modelBuilder.Entity(entityType.ClrType)
								.Property(property.Name)
								.HasConversion<string>();
				}
			}
		}

		modelBuilder.SeedCountries();

		// https://blog.jetbrains.com/dotnet/2023/06/14/how-to-implement-a-soft-delete-strategy-with-entity-framework-core/

		/* DOESN'T WORK ANYMORE WITH MY NEW BASECLASSES */
		// Apply global query filter for soft delete on entities inheriting from AuditableEntityWithSoftDelete
		//foreach (var entityType in modelBuilder.Model.GetEntityTypes())
		//{
		//    if (typeof(AuditableEntityWithSoftDelete).IsAssignableFrom(entityType.ClrType))
		//    {
		//        // Build lambda expression for the query filter: e => !e.IsDeleted
		//        var parameter = Expression.Parameter(entityType.ClrType, "e");
		//        var property = Expression.Property(parameter, nameof(AuditableEntityWithSoftDelete.IsDeleted));
		//        var filter = Expression.Lambda(Expression.Not(property), parameter);

		//        modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
		//    }
		//}

		/* DOESN'T WORK ANYMORE WITH MY NEW BASECLASSES */
		//modelBuilder.ApplySoftDeleteFilter();
		//modelBuilder.ConvertEnumsToStrings();
	}

	/* DOESN'T WORK WITH THE POOLING THAT IS SET UP WITH ASPIRE 
                TODO: SEARCH ALTERNATIVE APPROACH.
     */

	//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	//{
	//    base.OnConfiguring(optionsBuilder);

	//    //// Hacky logging to Console!
	//    optionsBuilder.LogTo(Console.WriteLine);
}
