using Ardalis.SmartEnum;
using DessertsMakery.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace DessertsMakery.Persistence.Database;

internal static class ModelBuilderExtensions
{
    public static ModelBuilder Seed<TEnum, TEntity>(
        this ModelBuilder builder,
        DatabaseFacade facade,
        Func<TEnum, TEntity> factory
    )
        where TEntity : Entity
        where TEnum : SmartEnum<TEnum>
    {
        var seeder = facade.GetInfrastructure().GetRequiredService<IEntitySeeder>();
        var entities = SmartEnum<TEnum>.List.Select(factory).ToArray();
        foreach (var entity in entities)
        {
            seeder.Seed(entity);
        }
        builder.Entity<TEntity>().HasData(seeder);
        return builder;
    }
}
