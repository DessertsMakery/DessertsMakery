using Ardalis.SmartEnum;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database;

internal static class ModelBuilderExtensions
{
    public static ModelBuilder Seed<TEnum, TEntity>(this ModelBuilder builder, Func<TEnum, TEntity> factory)
        where TEntity : class
        where TEnum : SmartEnum<TEnum>
    {
        builder.Entity<TEntity>().HasData(SmartEnum<TEnum>.List.Select(factory));
        return builder;
    }
}
