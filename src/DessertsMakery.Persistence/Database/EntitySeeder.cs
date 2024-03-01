using DessertsMakery.Common.Wrappers;
using DessertsMakery.Persistence.Models;

namespace DessertsMakery.Persistence.Database;

internal sealed class EntitySeeder : IEntitySeeder
{
    private readonly IGuidProvider _guidProvider;
    private readonly IDateTimeProvider _dateTimeProvider;

    public EntitySeeder(IGuidProvider guidProvider, IDateTimeProvider dateTimeProvider)
    {
        _guidProvider = guidProvider;
        _dateTimeProvider = dateTimeProvider;
    }

    public void Seed<TEntity>(TEntity entity)
        where TEntity : Entity
    {
        if (entity.ExternalId == Guid.Empty)
        {
            entity.ExternalId = _guidProvider.GetGuid();
        }

        var now = _dateTimeProvider.GetUtcNow();
        if (entity.CreatedAt == default)
        {
            entity.CreatedAt = now;
        }

        if (entity.ModifiedAt == default)
        {
            entity.ModifiedAt = now;
        }
    }
}
