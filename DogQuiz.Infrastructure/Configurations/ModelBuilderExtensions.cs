using DogQuiz.Domain.Aggregates.General.Bases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace DogQuiz.Infrastructure.Configurations;

public static class ModelBuilderExtensions
{
	// Applies a global soft delete filter to entities inheriting from AuditableEntityWithSoftDelete
	public static void ApplySoftDeleteFilter(this ModelBuilder modelBuilder)
	{
		foreach (var entityType in modelBuilder.Model.GetEntityTypes())
		{
			if (typeof(AuditableEntityWithSoftDelete).IsAssignableFrom(entityType.ClrType))
			{
				var filter = CreateSoftDeleteFilter(entityType.ClrType);
				modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
			}
		}
	}

	// Creates a filter expression for soft delete: e => !e.IsDeleted
	private static LambdaExpression CreateSoftDeleteFilter(Type entityType)
	{
		var parameter = Expression.Parameter(entityType, "e");
		var property = Expression.Property(parameter, nameof(AuditableEntityWithSoftDelete.IsDeleted));
		return Expression.Lambda(Expression.Not(property), parameter);
	}

	// Converts all enum properties to strings in the database
	public static void ConvertEnumsToStrings(this ModelBuilder modelBuilder)
	{
		foreach (var entityType in modelBuilder.Model.GetEntityTypes())
		{
			foreach (var property in entityType.GetProperties())
			{
				if (property.ClrType.IsEnum)
				{
					var entityBuilder = modelBuilder.Entity(entityType.ClrType);
					ApplyEnumToStringConversion(entityBuilder, property);
				}
			}
		}
	}

	// Applies string conversion for a specific enum property
	private static void ApplyEnumToStringConversion(EntityTypeBuilder entityBuilder, Microsoft.EntityFrameworkCore.Metadata.IMutableProperty property)
	{
		var converterType = typeof(EnumToStringConverter<>).MakeGenericType(property.ClrType);
		var converter = (ValueConverter)Activator.CreateInstance(converterType)!;

		entityBuilder.Property(property.Name).HasConversion(converter);
	}
}