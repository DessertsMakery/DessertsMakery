using Ardalis.SmartEnum;
using DessertsMakery.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database.Seeding.Enums;

internal abstract class EnumToEntitySeeder<TEnum, TEntity> : IModelSeeder
    where TEnum : SmartEnum<TEnum>
    where TEntity : Entity
{
    private readonly IEntitySeeder _entitySeeder;

    protected EnumToEntitySeeder(IEntitySeeder entitySeeder)
    {
        _entitySeeder = entitySeeder;
    }

    public void Use(ModelBuilder builder)
    {
        var entities = SmartEnum<TEnum>.List.Select(Map).ToArray();
        foreach (var entity in entities)
        {
            _entitySeeder.Seed(entity);
        }
        builder.Entity<TEntity>().HasData(entities);
    }

    protected abstract TEntity Map(TEnum @enum);
}
